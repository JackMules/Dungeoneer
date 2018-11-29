using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

namespace Dungeoneer.Utility
{
	public static class StatBlockImporter
	{
		public static List<int> GetNumbersFromString(string input)
		{
			string[] tokens = Regex.Split(input, @"\D+");
			List<int> numbers = new List<int>();
			foreach (string token in tokens)
			{
				try
				{
					numbers.Add(Convert.ToInt32(token));
				}
				catch (FormatException)
				{ }
			}

			return numbers;
		}

		public static Model.Creature ParseText(string text)
		{
			Model.CreatureAttributes attributes = new Model.CreatureAttributes();

			if (text != null && text != "")
			{
				string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
				string currentLine = "";
				try
				{
					foreach (string line in lines)
					{
						if (line != "")
						{
							currentLine = line;
							string[] splitLine = line.Split(':');
							string identifier = splitLine[0];
							string entry = splitLine[1];
							List<int> numbers = GetNumbersFromString(entry);
							string[] words = splitLine[1].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

							if (identifier == "Size/Type")
							{
								attributes.Size = Methods.GetSizeFromString(words[0]);
								attributes.Type = string.Join(" ", words.Skip(1));
							}
							else if (identifier == "Hit Dice")
							{
								attributes.HitDice = numbers[0];
								attributes.HitDieType = Methods.GetDieTypeFromInt(numbers[1]);
								attributes.HitPoints = numbers[3];
							}
							else if (identifier == "Initiative")
							{
								attributes.InitiativeMod = numbers[0];
							}
							else if (identifier == "Speed")
							{
								Model.SpeedSet speedSet = new Model.SpeedSet();

								string speedPattern = @"(?<LandSpeed>\d+).*,(?<OtherSpeeds>.*)";
								Regex speedRegex = new Regex(speedPattern, RegexOptions.IgnoreCase);
								Match speedMatch = speedRegex.Match(entry);

								attributes.Speed = speedSet;
							}
							else if (identifier == "Armor Class")
							{
								string acPattern = @"(?<AC>\d+)\s\(.*\),\stouch\s(?<TouchAC>\d+),\sflat\-footed\s(?<FFAC>\d+)";
								Regex acRegex = new Regex(acPattern, RegexOptions.IgnoreCase);
								Match acMatch = acRegex.Match(entry);

								if (acMatch.Success)
								{
									attributes.ArmorClass = Convert.ToInt32(acMatch.Groups["AC"].Value);
									attributes.TouchArmorClass = Convert.ToInt32(acMatch.Groups["TouchAC"].Value);
									attributes.FlatFootedArmorClass = Convert.ToInt32(acMatch.Groups["FFAC"].Value);
								}
							}
							else if (identifier == "Base Attack/Grapple")
							{
								attributes.BaseAttackBonus = numbers[0];
								attributes.GrappleModifier = numbers[1];
							}
							else if (identifier == "Attack" || identifier == "Full Attack")
							{
								string[] orStr = { "or" };
								foreach (string attackSetStr in entry.Split(orStr, StringSplitOptions.RemoveEmptyEntries))
								{
									Model.AttackSet attackSet = new Model.AttackSet
									{
										Name = identifier,
									};

									string attackPattern = @"(?<NumAttacks>\d+)?\s?(?<Name>(?!and\b)\b\D+)\s(?<AttackMod>[\+\-]\d+)\s(?<Type>\D+\s?\D*)\s\((?<Damage>[^\(]*)\)";
									Regex attackRegex = new Regex(attackPattern, RegexOptions.IgnoreCase);
									MatchCollection attackMatches = attackRegex.Matches(attackSetStr);
									foreach (Match attackMatch in attackMatches)
									{
										int numAttacks = 1;
										string name = attackMatch.Groups["Name"].Value;
										if (attackMatch.Groups["NumAttacks"].Value != "")
										{
											numAttacks = Convert.ToInt32(attackMatch.Groups["NumAttacks"].Value);
											PluralizationService ps = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
											name = ps.Singularize(name);
										}

										name = char.ToUpper(name[0]) + name.Substring(1);

										for (int i = 0; i < numAttacks; ++i)
										{
											Model.Attack attack = new Model.Attack();

											attack.Name = name;
											attack.Modifier = Convert.ToInt32(attackMatch.Groups["AttackMod"].Value);
											attack.Type = Methods.GetAttackTypeFromString(attackMatch.Groups["Type"].Value);

											string damageStr = attackMatch.Groups["Damage"].Value;
											string damagePattern = @"(?<NumDice>\d+)(?<Die>d\d+)(?<DamageMod>[\+\-]?\d*)\s?(?<DamageType>(?!plus\b)\b\w+)?";
											Regex damageRegex = new Regex(damagePattern, RegexOptions.IgnoreCase);
											MatchCollection damageMatches = damageRegex.Matches(damageStr);

											foreach (Match damageMatch in damageMatches)
											{
												Model.Damage damage = new Model.Damage();
												damage.NumDice = Convert.ToInt32(damageMatch.Groups["NumDice"].Value);
												damage.Die = Methods.GetDieTypeFromString(damageMatch.Groups["Die"].Value);
												if (damageMatch.Groups["DamageMod"].Value != "")
												{
													damage.Modifier = Convert.ToInt32(damageMatch.Groups["DamageMod"].Value);
												}
												if (damageMatch.Groups["DamageType"].Value != "")
												{
													damage.DamageDescriptorSet.Add(Methods.GetDamageTypeFromString(damageMatch.Groups["DamageType"].Value));
												}
												attack.Damages.Add(damage);
											}

											attackSet.Attacks.Add(attack);
										}
									}

									attributes.AttackSets.Add(attackSet);
								}
							}
							else if (identifier == "Space/Reach")
							{
								attributes.Space = numbers[0];
								attributes.Reach = numbers[1];
							}
							else if (identifier == "Special Attacks")
							{
								attributes.SpecialAttacks = entry.Trim();
							}
							else if (identifier == "Special Qualities")
							{
								attributes.SpecialQualities = entry.Trim();

								string drPattern = @"damage reduction (?<Value>\d+)\/(?<Types>.+?)(\,|\z)";
								Regex drRegex = new Regex(drPattern, RegexOptions.IgnoreCase);
								MatchCollection drMatches = drRegex.Matches(entry);

								foreach (Match drMatch in drMatches)
								{
									Model.DamageReduction dr = new Model.DamageReduction();
									dr.Value = Convert.ToInt32(drMatch.Groups["Value"].Value);
									dr.DamageTypes = GetDamageDescriptorSetFromString(drMatch.Groups["Types"].Value, "and");
									attributes.DamageReductions.Add(dr);
								}

								string immunityPattern = @"immunity to (?<Types>.+?)(\,|\z)";
								Regex immunityRegex = new Regex(immunityPattern, RegexOptions.IgnoreCase);
								Match immunityMatch = immunityRegex.Match(entry);

								if (immunityMatch.Success)
								{
									Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(immunityMatch.Groups["Types"].Value, "and");
									foreach (Types.Damage damageType in damageTypes.ToList())
									{
										attributes.Immunities.Add(damageType);
									}
								}

								string resistancesPattern = @"resistance to (?<Types>.+?)(\,|\z)";
								Regex resistancesRegex = new Regex(resistancesPattern, RegexOptions.IgnoreCase);
								Match resistancesMatch = resistancesRegex.Match(entry);

								if (resistancesMatch.Success)
								{
									string resistancePattern = @"(?<Type>[a-z]+)\s(?<Value>\d+)";
									Regex resistanceRegex = new Regex(resistancePattern, RegexOptions.IgnoreCase);
									MatchCollection resistanceMatches = resistanceRegex.Matches(resistancesMatch.Groups["Types"].Value);

									foreach (Match resistanceMatch in resistanceMatches)
									{
										Model.DamageReduction res = new Model.DamageReduction();
										res.Value = Convert.ToInt32(resistanceMatch.Groups["Value"].Value);
										res.DamageTypes = GetDamageDescriptorSetFromString(resistanceMatch.Groups["Type"].Value);
										attributes.DamageReductions.Add(res);
									}
								}

								string spellResistancePattern = @"spell resistance (?<Value>\d+)(\,|\z)";
								Regex spellResistanceRegex = new Regex(spellResistancePattern, RegexOptions.IgnoreCase);
								Match spellResistanceMatch = spellResistanceRegex.Match(entry);

								if (spellResistanceMatch.Success)
								{
									attributes.SpellResistance = Convert.ToInt32(spellResistanceMatch.Groups["Value"].Value);
								}
							}
							else if (identifier == "Saves")
							{
								attributes.FortitudeSave = numbers[0];
								attributes.ReflexSave = numbers[1];
								attributes.WillSave = numbers[2];
							}
							else if (identifier == "Abilities")
							{
								attributes.Strength = numbers[0];
								attributes.Dexterity = numbers[1];
								attributes.Constitution = numbers[2];
								attributes.Intelligence = numbers[3];
								attributes.Wisdom = numbers[4];
								attributes.Charisma = numbers[5];
							}
							else if (identifier == "Feats")
							{
								foreach (string feat in entry.Split(','))
								{
									attributes.Feats.Add(feat.Trim());
								}
							}
							else if (identifier == "Challenge Rating")
							{
								if (numbers.Count == 2)
								{
									attributes.ChallengeRating = numbers[0] / numbers[1];
								}
								else
								{
									attributes.ChallengeRating = numbers[0];
								}
							}
						}
					}
				}
				catch (FormatException e)
				{
					MessageBox.Show("Cannot parse:\n" + currentLine);
					throw e;
				}
			}

			Model.Creature creature = new Model.Creature(attributes);

			return creature;
		}

		private static Model.DamageDescriptorSet GetDamageDescriptorSetFromString(string str, string separator = null)
		{
			string separatorStr = separator != null ? @"(?!" + separator + @"\b)\b" : separator;
			string typePattern = separatorStr + @"[a-z]+";	
			Regex typeRegex = new Regex(typePattern, RegexOptions.IgnoreCase);
			MatchCollection typeMatches = typeRegex.Matches(str);
			Model.DamageDescriptorSet damageDescriptorSet = new Model.DamageDescriptorSet();

			foreach (Match typeMatch in typeMatches)
			{
				try
				{
					damageDescriptorSet.Add(Methods.GetDamageTypeFromString(typeMatch.Value));
				}
				catch (FormatException)
				{
					// Format not recognised, never mind
				}
			}

			return damageDescriptorSet;
		}

		private static Model.Attack GetAttack(string name, int attackMod, Types.Attack attackType, List<Model.Damage> damages)
		{
			Model.Attack attack = new Model.Attack();
			attack.Name = name;
			attack.Modifier = attackMod;
			attack.Type = attackType;
			foreach (Model.Damage damage in damages)
			{
				attack.Damages.Add(damage);
			}
			return attack;
		}

		private static Model.Damage GetDamage(int numDice, Types.Die die, int damageMod, string[] damageTypeStrings)
		{
			Model.Damage damage = new Model.Damage();
			damage.NumDice = numDice;
			damage.Die = die;
			damage.Modifier = damageMod;
			foreach (string damageTypeString in damageTypeStrings)
			{
				damage.DamageDescriptorSet.Add(Methods.GetDamageTypeFromString(damageTypeString));
			}
			
			return damage;
		}
	}
}

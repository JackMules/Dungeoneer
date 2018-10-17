using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
			Model.Creature creature = new Model.Creature();

			if (text != null && text != "")
			{
				string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
				string currentLine = "";
				try
				{
					foreach (string line in lines)
					{
						currentLine = line;
						string[] splitLine = line.Split(':');
						string identifier = splitLine[0];
						string entry = splitLine[1];
						List<int> numbers = GetNumbersFromString(entry);
						string[] tokens = splitLine[1].Split(' ');
						List<string> words = new List<string>();
						foreach (string token in tokens)
						{
							if (token != "")
							{
								words.Add(token);
							}
						}

						if (identifier == "Size/Type")
						{
							creature.Size = Methods.GetSizeFromString(words[0]);
							creature.Type = string.Join(" ", words.Skip(1));
						}
						else if (identifier == "Hit Dice")
						{
							creature.HitDice = numbers[0];
							creature.HitDieType = Methods.GetDieTypeFromInt(numbers[1]);
							creature.HitPoints = numbers[3];
						}
						else if (identifier == "Initiative")
						{
							creature.InitiativeMod = numbers[0];
						}
						else if (identifier == "Speed")
						{
							creature.Speed = numbers[0];
						}
						else if (identifier == "Armor Class")
						{
							string acPattern = @"(?<AC>\d+)\s\(.*\),\stouch\s(?<TouchAC>\d+),\sflat\-footed\s(?<FFAC>\d+)";
							Regex acRegex = new Regex(acPattern, RegexOptions.IgnoreCase);
							Match acMatch = acRegex.Match(entry);

							if (acMatch.Success)
							{
								creature.ArmorClass = Convert.ToInt32(acMatch.Groups["AC"].Value);
								creature.TouchArmorClass = Convert.ToInt32(acMatch.Groups["TouchAC"].Value);
								creature.FlatFootedArmorClass = Convert.ToInt32(acMatch.Groups["FFAC"].Value);
							}
						}
						else if (identifier == "Base Attack/Grapple")
						{
							creature.BaseAttackBonus = numbers[0];
							creature.GrappleModifier = numbers[1];
						}
						else if (identifier == "Attack" || identifier == "Full Attack")
						{
							Model.AttackSet attackSet = new Model.AttackSet
							{
								Name = identifier,
							};

							string attackPattern = @"(?<NumAttacks>\d+)?\s(?<Name>(?!and\b)\b\D+)\s(?<AttackMod>[\+\-]\d+)\s(?<Type>\D+\s?\D*)\s\((?<Damage>[^\(]*)\)";
							Regex attackRegex = new Regex(attackPattern, RegexOptions.IgnoreCase);
							MatchCollection attackMatches = attackRegex.Matches(entry);
							foreach (Match attackMatch in attackMatches)
							{
								int numAttacks = 1;

								if (attackMatch.Groups["NumAttacks"].Value != "")
								{
									Convert.ToInt32(attackMatch.Groups["NumAttacks"].Value);
								}

								for (int i = 0; i < numAttacks; ++i)
								{
									Model.Attack attack = new Model.Attack();
									
									attack.Name = attackMatch.Groups["Name"].Value;
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
							
							creature.AttackSets.Add(attackSet);
						}
						else if (identifier == "Space/Reach")
						{

						}
						else if (identifier == "Special Attacks")
						{

						}
						else if (identifier == "Special Qualities")
						{
							string drPattern = @"damage reduction (?<Value>\d+)\/(?<Types>.+?)\,";
							Regex drRegex = new Regex(drPattern, RegexOptions.IgnoreCase);
							MatchCollection drMatches = drRegex.Matches(entry);

							foreach (Match drMatch in drMatches)
							{
								Model.DamageReduction dr = new Model.DamageReduction();
								dr.Value = Convert.ToInt32(drMatch.Groups["Value"].Value);
								dr.DamageTypes = GetDamageDescriptorSetFromString(drMatch.Groups["Types"].Value, "and");
								creature.DamageReductions.Add(dr);
							}

							string immunityPattern = @"immunity to (?<Types>.+?)\,";
							Regex immunityRegex = new Regex(immunityPattern, RegexOptions.IgnoreCase);
							Match immunityMatch = immunityRegex.Match(entry);

							if (immunityMatch.Success)
							{
								Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(immunityMatch.Groups["Types"].Value, "and");
								foreach (Types.Damage damageType in damageTypes.ToList())
								{
									creature.Immunities.Add(damageType);
								}
							}

							string resistancePattern = @"";

						}
						else if (identifier == "Saves")
						{
							creature.FortitudeSave = numbers[0];
							creature.ReflexSave = numbers[1];
							creature.WillSave = numbers[2];
						}
						else if (identifier == "Abilities")
						{
							creature.Strength = numbers[0];
							creature.Dexterity = numbers[1];
							creature.Constitution = numbers[2];
							creature.Intelligence = numbers[3];
							creature.Wisdom = numbers[4];
							creature.Charisma = numbers[5];
						}
						else if (identifier == "Challenge Rating")
						{
							if (numbers.Count == 2)
							{
								creature.ChallengeRating = numbers[0] / numbers[1];
							}
							else
							{
								creature.ChallengeRating = numbers[0];
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

			return creature;
		}

		private static Model.DamageDescriptorSet GetDamageDescriptorSetFromString(string str, string separator)
		{
			string typePattern = @"(?!" + separator + @"\b)\b\w+";
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

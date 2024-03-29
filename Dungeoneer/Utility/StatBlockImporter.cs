﻿using System;
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

		public static Model.Creature ParseMM4Text(string text)
		{
			Model.CreatureAttributes attributes = new Model.CreatureAttributes();

			if (text != "")
			{
				string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
				string currentLine = "";
				try
				{
					for (int l = 0; l < lines.Count(); ++l)
					{
						currentLine = lines[l];

						// Parse one-line data types
						ParseChallengeRating(attributes, currentLine);
						ParseSaves(attributes, currentLine);
						ParseBaseAttackAndGrapple(attributes, currentLine);
						ParseSpaceAndReach(attributes, currentLine);
						ParseAbilities(attributes, currentLine);
						ParseResistances(attributes, currentLine);
						ParseSpellResistance(attributes, currentLine);
						ParseImmunities(attributes, currentLine);
						ParseVulnerabilities(attributes, currentLine);
						ParseSpeed(attributes, currentLine);
						ParseArmorClass(attributes, currentLine);
						ParseAlignmentSizeAndType(attributes, currentLine);
						ParseInitiative(attributes, currentLine);
						ParseHitPoints(attributes, currentLine);
						ParseFeats(attributes, currentLine);
						ParseAttacks(attributes, currentLine);
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

		private static void ParseAttack(Model.CreatureAttributes attributes, string str, Types.Attack attackType)
		{
			Model.AttackSet attackSet = new Model.AttackSet
			{
				Name = "Full Attack",
			};

			string attacksPattern = @"(?<NumAttacks>\d+)?\s?(?<Name>\D+)\s(?<HitMod>[+-]\d+)(\seach)?\s(\((?<Damage>[^\(]*)\))?";
			Regex attacksRegex = new Regex(attacksPattern, RegexOptions.IgnoreCase);
			MatchCollection attackMatches = attacksRegex.Matches(str);
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
					attack.Modifier = Convert.ToInt32(attackMatch.Groups["HitMod"].Value);
					attack.Type = attackType;

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

		private static void ParseAttacks(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Melee\s(?<Attacks>.*)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				ParseAttack(attributes, match.Groups["Attacks"].Value, Types.Attack.Melee);
			}

			pattern = @"Ranged\s(?<Attacks>.*)";
			regex = new Regex(pattern);
			match = regex.Match(str);

			if (match.Success)
			{
				ParseAttack(attributes, match.Groups["Attacks"].Value, Types.Attack.Ranged);
			}
		}

		private static void ParseFeats(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Feats\s(?<Feats>.+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				foreach (string feat in match.Groups["Feats"].Value.Split(','))
				{
					feat.Trim();
					feat.Trim('*');
					feat.Trim();
					attributes.Feats.Add(feat);
				}

				if (attributes.WeaponFinesse)
				{
					foreach (Model.AttackSet attackSet in attributes.AttackSets)
					{
						foreach (Model.Attack attack in attackSet.Attacks)
						{
							if (attack.Type == Types.Attack.Melee ||
								attack.Type == Types.Attack.MeleeTouch ||
								attack.Type == Types.Attack.IncorporealTouch)
							{
								attack.Ability = Types.Ability.Dexterity;
							}
						}
					}
				}
			}
		}

		private static void ParseHitPoints(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"hp\s(?<HP>\d+)\s\((?<HD>\d+)\sHD\)(;\sfast\shealing\s(?<FastHealing>\d+))?(;\s(?<DR>DR\s.*))?";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match match = regex.Match(str);

			if (match.Success)
			{
				attributes.HitPoints = Convert.ToInt32(match.Groups["HP"].Value);
				attributes.HitDice = Convert.ToInt32(match.Groups["HD"].Value);

				if (match.Groups["FastHealing"].Success)
				{
					attributes.FastHealing = Convert.ToInt32(match.Groups["FastHealing"].Value);
				}

				if (match.Groups["DR"].Success)
				{
					string drStr = match.Groups["DR"].Value;
					string drPattern = @"(?<Value>\d+)\/(?<Types>.+?)(\,|\z)";
					Regex drRegex = new Regex(drPattern, RegexOptions.IgnoreCase);
					MatchCollection drMatches = drRegex.Matches(drStr);

					foreach (Match drMatch in drMatches)
					{
						Model.DamageReduction dr = new Model.DamageReduction();
						dr.Value = Convert.ToInt32(drMatch.Groups["Value"].Value);
						dr.DamageTypes = GetDamageDescriptorSetFromString(drMatch.Groups["Types"].Value, "and");
						attributes.DamageReductions.Add(dr);
					}
				}
			}
		}

		private static void ParseInitiative(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Init\s(?<Init>[\+\-]\d+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.InitiativeMod = Convert.ToInt32(match.Groups["Init"].Value);
				}
				catch (FormatException)
				{
					attributes.InitiativeMod = 0;
				}
			}
		}

		private static void ParseAlignmentSizeAndType(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"(?<Alignment>LG|NG|CG|LN|N|CN|LE|NE|CE)\s(?<Size>Fine|Diminuative|Tiny|Small|Medium|Large|Huge|Gargantuan|Colossal)\s(?<Type>[A-Za-z]+)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match match = regex.Match(str);

			if (match.Success)
			{
				attributes.Size = Methods.GetSizeFromString(match.Groups["Size"].Value);
				attributes.Type = Methods.GetCreatureTypeFromString(match.Groups["Type"].Value);
			}
		}

		private static void ParseArmorClass(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"(?<AC>\d+),\s*touch\s*(?<TouchAC>\d+),\s*flat\-footed\s*(?<FFAC>\d+)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match match = regex.Match(str);

			if (match.Success)
			{
				attributes.ArmorClass = Convert.ToInt32(match.Groups["AC"].Value);
				attributes.TouchArmorClass = Convert.ToInt32(match.Groups["TouchAC"].Value);
				attributes.FlatFootedArmorClass = Convert.ToInt32(match.Groups["FFAC"].Value);
			}
		}

		private static void ParseSpeed(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Speed\s+(?<LandSpeed>\d+)\s+ft.\s*\(\d+\ssquares\)(,\s?(?<OtherSpeeds>.+))?";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				attributes.Speed.LandSpeed = Convert.ToInt32(match.Groups["LandSpeed"].Value);

				string speedPattern = @"\s?(?<Type>\w+)\s(?<Speed>\d+)\s*ft.\s?(\((?<Manouverability>\w+)\))?";
				Regex speedRegex = new Regex(speedPattern, RegexOptions.IgnoreCase);
				MatchCollection speedMatches = speedRegex.Matches(match.Groups["OtherSpeeds"].Value);

				foreach (Match speedMatch in speedMatches)
				{
					Types.Manouverability manouverability = Types.Manouverability.None;
					if (speedMatch.Groups["Manouverability"].Success)
					{
						manouverability = Methods.GetManouverabilityFromString(speedMatch.Groups["Manouverability"].Value);
					}
					int distance = Convert.ToInt32(speedMatch.Groups["Speed"].Value);
					string movementString = speedMatch.Groups["Type"].Value.Trim();

					Types.Movement movementType = Methods.GetMovementTypeFromString(movementString);
					attributes.Speed.Speeds.Add(new Model.Speed(distance, movementType, manouverability));
				}
			}
		}

		private static void ParseImmunities(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Immune\s?(?<Immunities>.+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				string immunityPattern = @"(?<Type>[a-z]+)(\,|\z)";
				Regex immunityRegex = new Regex(immunityPattern, RegexOptions.IgnoreCase);
				MatchCollection immunityMatches = immunityRegex.Matches(match.Groups["Immunities"].Value);

				foreach (Match immunityMatch in immunityMatches)
				{
					Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(immunityMatch.Groups["Type"].Value, "and");
					foreach (Types.Damage damageType in damageTypes.ToList())
					{
						if (damageType != Types.Damage.Magic) // Immunity to magic does not mean immunity to magic weapons
						{
							attributes.Immunities.Add(damageType);
						}
					}
				}
			}
		}

		private static void ParseVulnerabilities(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Vulnerability\sto\s?(?<Immunities>.+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				string vulnerabilityPattern = @"(?<Type>[a-z]+)(\,|\z)";
				Regex vulnerabilityRegex = new Regex(vulnerabilityPattern, RegexOptions.IgnoreCase);
				MatchCollection vulnerabilityMatches = vulnerabilityRegex.Matches(match.Groups["Vulnerabilities"].Value);

				foreach (Match vulnerabilityMatch in vulnerabilityMatches)
				{
					Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(vulnerabilityMatch.Groups["Type"].Value, "and");
					foreach (Types.Damage damageType in damageTypes.ToList())
					{
						attributes.Vulnerabilities.Add(damageType);
					}
				}
			}
		}

		private static void ParseResistances(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Resist\s?(?<Resistances>[^;]+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				string resistancePattern = @"(?<Type>[a-z]+)\s(?<Value>\d+)";
				Regex resistanceRegex = new Regex(resistancePattern, RegexOptions.IgnoreCase);
				MatchCollection resistanceMatches = resistanceRegex.Matches(match.Groups["Resistances"].Value);

				foreach (Match resistanceMatch in resistanceMatches)
				{
					Model.EnergyResistance res = new Model.EnergyResistance();
					try
					{
						res.Value = Convert.ToInt32(resistanceMatch.Groups["Value"].Value);
					}
					catch (FormatException)
					{
						res.Value = 0;
					}

					try
					{
						res.EnergyType = Methods.GetDamageTypeFromString(resistanceMatch.Groups["Type"].Value);
					}
					catch (FormatException)
					{
						res.EnergyType = Types.Damage.Subdual;
					}
					attributes.EnergyResistances.Add(res);
				}

				
			}
		}

		private static void ParseSpellResistance(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"SR\s(?<SR>\w+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.SpellResistance = Convert.ToInt32(match.Groups["SR"].Value);
				}
				catch (FormatException)
				{
					attributes.SpellResistance = 0;
				}
			}
		}

		private static void ParseChallengeRating(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"CR\s(?<CR>\w+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.ChallengeRating = Convert.ToInt32(match.Groups["CR"].Value);
				}
				catch (FormatException)
				{
					attributes.ChallengeRating = 0;
				}
			}
		}

		private static void ParseSaves(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Fort\s(?<Fort>[\+\-]\d+)\s?(\(.+\))?,?\s+Ref\s(?<Ref>[\+\-]\d+)\s?(\(.+\))?,?\s+Will?\s(?<Will>[\+\-]\d+)\s?(\(.+\))?";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.FortitudeSave = Convert.ToInt32(match.Groups["Fort"].Value);
				}
				catch (FormatException)
				{
					attributes.FortitudeSave = 0;
				}

				try
				{
					attributes.ReflexSave = Convert.ToInt32(match.Groups["Ref"].Value);
				}
				catch (FormatException)
				{
					attributes.ReflexSave = 0;
				}

				try
				{
					attributes.WillSave = Convert.ToInt32(match.Groups["Will"].Value);
				}
				catch (FormatException)
				{
					attributes.WillSave = 0;
				}
			}
		}

		private static void ParseBaseAttackAndGrapple(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Base Atk\s(?<BAB>\S+);\s+Grp\s(?<Grapple>\S+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.BaseAttackBonus = Convert.ToInt32(match.Groups["BAB"].Value);
				}
				catch (FormatException)
				{
					attributes.BaseAttackBonus = 0;
				}

				try
				{
					attributes.GrappleModifier = Convert.ToInt32(match.Groups["Grapple"].Value);
				}
				catch (FormatException)
				{
					attributes.GrappleModifier = 0;
				}
			}
		}

		private static void ParseSpaceAndReach(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Space\s(?<Space>\w+)\s?ft\.,?;?\s+Reach\s(?<Reach>\w+)\s?ft\.";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.Space = Convert.ToInt32(match.Groups["Space"].Value);
				}
				catch (FormatException)
				{
					attributes.Space = 5;
				}

				try
				{
					attributes.Reach = Convert.ToInt32(match.Groups["Reach"].Value);
				}
				catch (FormatException)
				{
					attributes.Reach = 5;
				}
			}
		}

		private static void ParseAbilities(Model.CreatureAttributes attributes, string str)
		{
			string pattern = @"Str\s(?<Str>\S+),\s+Dex\s(?<Dex>\S+),\s+Con\s(?<Con>\S+),\s+Int\s(?<Int>\S+),\s+Wis\s(?<Wis>\S+),\s+Cha\s(?<Cha>\S+)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(str);

			if (match.Success)
			{
				try
				{
					attributes.Strength = Convert.ToInt32(match.Groups["Str"].Value);
				}
				catch (FormatException)
				{
					attributes.Strength = 0;
				}

				try
				{
					attributes.Dexterity = Convert.ToInt32(match.Groups["Dex"].Value);
				}
				catch (FormatException)
				{
					attributes.Dexterity = 0;
				}

				try
				{
					attributes.Constitution = Convert.ToInt32(match.Groups["Con"].Value);
				}
				catch (FormatException)
				{
					attributes.Constitution = 0;
				}

				try
				{
					attributes.Intelligence = Convert.ToInt32(match.Groups["Int"].Value);
				}
				catch (FormatException)
				{
					attributes.Intelligence = 0;
				}

				try
				{
					attributes.Wisdom = Convert.ToInt32(match.Groups["Wis"].Value);
				}
				catch (FormatException)
				{
					attributes.Wisdom = 0;
				}

				try
				{
					attributes.Charisma = Convert.ToInt32(match.Groups["Cha"].Value);
				}
				catch (FormatException)
				{
					attributes.Charisma = 0;
				}
			}
		}

		public static Model.Creature ParseSRDText(string text)
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
						currentLine = line;
						if (currentLine != "")
						{
							string[] splitLine = line.Split(':');
							if (splitLine.Length != 2)
							{
								throw new FormatException();
							}
							else
							{
								string identifier = splitLine[0];
								string entry = splitLine[1];
								List<int> numbers = GetNumbersFromString(entry);
								string[] words = splitLine[1].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

								if (identifier == "Size/Type")
								{
									attributes.Size = Methods.GetSizeFromString(words[0]);
									string typeStr = string.Join(" ", words.Skip(1));

									string typePattern = @"\s*(?<Type>\w+\s?\w*)\s*(\((?<SubTypes>\D+)\))?";
									Regex typeRegex = new Regex(typePattern, RegexOptions.IgnoreCase);
									Match typeMatch = typeRegex.Match(typeStr);

									if (typeMatch.Success)
									{
										attributes.Type = Methods.GetCreatureTypeFromString(typeMatch.Groups["Type"].Value);
										/*
										if (typeMatch.Groups.Count > 1)
										{
											string subTypes = typeMatch.Groups["SubTypes"].Value;

											string subTypePattern = @"\s*(?<Type>\w+)\s*(\((?<SubTypes>\D+)\))?";
											Regex subTypeRegex = new Regex(subTypePattern, RegexOptions.IgnoreCase);
											Match subTypeMatch = subTypeRegex.Match(entry);

											if (subTypeMatch.Success)
											{
												attributes.Subtypes = Methods.GetCreatureSubTypeFromString();
											}
										}
										*/
									}
								}
								else if (identifier == "Hit Dice")
								{
									string hpPattern = @"\s?(?<NumHD>\d+)(?<HDType>[dD]\d+)\s?(?<HDMod>[\+\-]\d+)?\s?\((?<HP>\d+)\s?hp\)";
									Regex hpRegex = new Regex(hpPattern, RegexOptions.IgnoreCase);
									Match hpMatch = hpRegex.Match(entry);

									if (hpMatch.Success)
									{
										attributes.HitDice = Convert.ToInt32(hpMatch.Groups["NumHD"].Value);
										attributes.HitDieType = Methods.GetDieTypeFromString(hpMatch.Groups["HDType"].Value);
										attributes.HitPoints = Convert.ToInt32(hpMatch.Groups["HP"].Value);
									}
								}
								else if (identifier == "Initiative")
								{
									attributes.InitiativeMod = numbers[0];
								}
								else if (identifier == "Speed")
								{
									char[] commaChar = { ',' };

									foreach (string speedStr in entry.Split(commaChar, StringSplitOptions.RemoveEmptyEntries))
									{
										string speedPattern = @"\s?(?<Type>\D*)\s(?<Speed>\d+)\s*ft.\s*(\((?<Manouverability>\w+)\))?";
										Regex speedRegex = new Regex(speedPattern, RegexOptions.IgnoreCase);
										Match speedMatch = speedRegex.Match(speedStr);

										if (speedMatch.Success)
										{
											Types.Manouverability manouverability = Types.Manouverability.None;
											if (speedMatch.Groups["Manouverability"].Success)
											{
												manouverability = Methods.GetManouverabilityFromString(speedMatch.Groups["Manouverability"].Value);
											}
											int distance = Convert.ToInt32(speedMatch.Groups["Speed"].Value);
											string movementString = speedMatch.Groups["Type"].Value.Trim();
											if (movementString.Equals(""))
											{
												attributes.Speed.LandSpeed = distance;
											}
											else
											{
												Types.Movement movementType = Methods.GetMovementTypeFromString(movementString);
												attributes.Speed.Speeds.Add(new Model.Speed(distance, movementType, manouverability));
											}
										}
									}
								}
								else if (identifier == "Armor Class")
								{
									string acPattern = @"(?<AC>\d+)\s\(.*\),\s*touch\s*(?<TouchAC>\d+),\s*flat\-footed\s*(?<FFAC>\d+)";
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
									if (numbers.Count > 1)
										attributes.GrappleModifier = numbers[1];
								}
								else if (identifier == "Attack" || identifier == "Full Attack")
								{
									string[] splitStrs = { " or " };
									foreach (string attackSetStr in entry.Split(splitStrs, StringSplitOptions.RemoveEmptyEntries))
									{
										Model.AttackSet attackSet = new Model.AttackSet
										{
											Name = identifier,
										};

										string attackPattern = @"(?<WeaponMod>\+\d)?(?<NumAttacks>\d+)?\s?(?<Name>(?!and\b)\b\D+)\s(?<AttackMod>[\+\-]\d+)\/?(?<AttackMod2>[\+\-]\d+)?\/?(?<AttackMod3>[\+\-]\d+)?\/?(?<AttackMod4>[\+\-]\d+)?\/?(?<AttackMod5>[\+\-]\d+)?\s(?<Type>\D+\s?\D*)\s\((?<Damage>[^\(]*)\)";
										Regex attackRegex = new Regex(attackPattern, RegexOptions.IgnoreCase);
										MatchCollection attackMatches = attackRegex.Matches(attackSetStr);
										foreach (Match attackMatch in attackMatches)
										{
											int numAttacks = 1;
											List<int> attackMods = new List<int> { Convert.ToInt32(attackMatch.Groups["AttackMod"].Value) };
											string name = "";
											if (attackMatch.Groups["AttackMod2"].Value != "")
											{
												++numAttacks;
												attackMods.Add(Convert.ToInt32(attackMatch.Groups["AttackMod2"].Value));
												if (attackMatch.Groups["AttackMod3"].Value != "")
												{
													++numAttacks;
													attackMods.Add(Convert.ToInt32(attackMatch.Groups["AttackMod3"].Value));
													if (attackMatch.Groups["AttackMod4"].Value != "")
													{
														++numAttacks;
														attackMods.Add(Convert.ToInt32(attackMatch.Groups["AttackMod4"].Value));
														if (attackMatch.Groups["AttackMod5"].Value != "")
														{
															++numAttacks;
															attackMods.Add(Convert.ToInt32(attackMatch.Groups["AttackMod5"].Value));
														}
													}
												}
											}
											else if (attackMatch.Groups["NumAttacks"].Value != "")
											{
												numAttacks = Convert.ToInt32(attackMatch.Groups["NumAttacks"].Value);
											}

											if (attackMatch.Groups["NumAttacks"].Value != "")
											{
												name = attackMatch.Groups["WeaponMod"].Value + " " + attackMatch.Groups["Name"].Value;
											}
											else
											{
												name = attackMatch.Groups["Name"].Value;
											}

											if (numAttacks > 1)
											{
												PluralizationService ps = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
												name = ps.Singularize(name);
											}

											name = char.ToUpper(name[0]) + name.Substring(1);

											for (int i = 0; i < numAttacks; ++i)
											{
												Model.Attack attack = new Model.Attack();

												attack.Name = name;
												if (attackMods.Count > 1)
												{
													attack.Modifier = attackMods[i];
												}
												else
												{
													attack.Modifier = attackMods[0];
												}
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
									foreach (string specialQuality in entry.Split(','))
									{
										attributes.SpecialQualities.Add(specialQuality.Trim());
									}

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
									MatchCollection immunityMatches = immunityRegex.Matches(entry);

									foreach (Match immunityMatch in immunityMatches)
									{
										Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(immunityMatch.Groups["Types"].Value, "and");
										foreach (Types.Damage damageType in damageTypes.ToList())
										{
											if (damageType != Types.Damage.Magic) // Immunity to magic does not mean immunity to magic weapons
											{
												attributes.Immunities.Add(damageType);
											}
										}
									}

									string vulnerabilityPattern = @"vulnerability to (?<Types>.+?)(\,|\z)";
									Regex vulnerabilityRegex = new Regex(vulnerabilityPattern, RegexOptions.IgnoreCase);
									MatchCollection vulnerabilityMatches = vulnerabilityRegex.Matches(entry);

									foreach (Match vulnerabilityMatch in vulnerabilityMatches)
									{
										Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(vulnerabilityMatch.Groups["Types"].Value, "and");
										foreach (Types.Damage damageType in damageTypes.ToList())
										{
											attributes.Vulnerabilities.Add(damageType);
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
											Model.EnergyResistance res = new Model.EnergyResistance();
											res.Value = Convert.ToInt32(resistanceMatch.Groups["Value"].Value);
											res.EnergyType = Methods.GetDamageTypeFromString(resistanceMatch.Groups["Type"].Value);
											attributes.EnergyResistances.Add(res);
										}
									}

									string spellResistancePattern = @"spell resistance (?<Value>\d+)(\,|\z)";
									Regex spellResistanceRegex = new Regex(spellResistancePattern, RegexOptions.IgnoreCase);
									Match spellResistanceMatch = spellResistanceRegex.Match(entry);

									if (spellResistanceMatch.Success)
									{
										attributes.SpellResistance = Convert.ToInt32(spellResistanceMatch.Groups["Value"].Value);
									}

									string regenerationPattern = @"regeneration (?<Value>\d+)(\,|\z)";
									Regex regenerationRegex = new Regex(regenerationPattern, RegexOptions.IgnoreCase);
									Match regenerationMatch = regenerationRegex.Match(entry);

									if (regenerationMatch.Success)
									{
										attributes.FastHealing = Convert.ToInt32(regenerationMatch.Groups["Value"].Value);
									}

									string fastHealingPattern = @"fast healing (?<Value>\d+)(\,|\z)";
									Regex fastHealingRegex = new Regex(fastHealingPattern, RegexOptions.IgnoreCase);
									Match fastHealingMatch = fastHealingRegex.Match(entry);

									if (fastHealingMatch.Success)
									{
										attributes.FastHealing = Convert.ToInt32(fastHealingMatch.Groups["Value"].Value);
									}

									string halfDamagePattern = @"half damage from (?<Types>.+?)(\,|\z)";
									Regex halfDamageRegex = new Regex(halfDamagePattern, RegexOptions.IgnoreCase);
									MatchCollection halfDamageMatches = halfDamageRegex.Matches(entry);

									foreach (Match halfDamageMatch in halfDamageMatches)
									{
										Model.DamageDescriptorSet damageTypes = GetDamageDescriptorSetFromString(halfDamageMatch.Groups["Types"].Value, "and");
										foreach (Types.Damage damageType in damageTypes.ToList())
										{
											attributes.HalfDamage.Add(damageType);
										}
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
									string attributePattern = @"Str\s(?<Value>\w+)";
									Regex attributeRegex = new Regex(attributePattern, RegexOptions.IgnoreCase);
									Match attributeMatch = attributeRegex.Match(entry);

									if (attributeMatch.Success)
									{
										try
										{
											attributes.Strength = Convert.ToInt32(attributeMatch.Groups["Value"].Value);
										}
										catch (FormatException)
										{
											attributes.Strength = 0;
										}
									}

									attributePattern = @"Dex\s(?<Value>\w+)";
									attributeRegex = new Regex(attributePattern, RegexOptions.IgnoreCase);
									attributeMatch = attributeRegex.Match(entry);

									if (attributeMatch.Success)
									{
										try
										{
											attributes.Dexterity = Convert.ToInt32(attributeMatch.Groups["Value"].Value);
										}
										catch (FormatException)
										{
											attributes.Dexterity = 0;
										}
									}

									attributePattern = @"Con\s(?<Value>\w+)";
									attributeRegex = new Regex(attributePattern, RegexOptions.IgnoreCase);
									attributeMatch = attributeRegex.Match(entry);

									if (attributeMatch.Success)
									{
										try
										{
											attributes.Constitution = Convert.ToInt32(attributeMatch.Groups["Value"].Value);
										}
										catch (FormatException)
										{
											attributes.Constitution = 0;
										}
									}

									attributePattern = @"Int\s(?<Value>\w+)";
									attributeRegex = new Regex(attributePattern, RegexOptions.IgnoreCase);
									attributeMatch = attributeRegex.Match(entry);

									if (attributeMatch.Success)
									{
										try
										{
											attributes.Intelligence = Convert.ToInt32(attributeMatch.Groups["Value"].Value);
										}
										catch (FormatException)
										{
											attributes.Intelligence = 0;
										}
									}

									attributePattern = @"Wis\s(?<Value>\w+)";
									attributeRegex = new Regex(attributePattern, RegexOptions.IgnoreCase);
									attributeMatch = attributeRegex.Match(entry);

									if (attributeMatch.Success)
									{
										try
										{
											attributes.Wisdom = Convert.ToInt32(attributeMatch.Groups["Value"].Value);
										}
										catch (FormatException)
										{
											attributes.Wisdom = 0;
										}
									}

									attributePattern = @"Cha\s(?<Value>\w+)";
									attributeRegex = new Regex(attributePattern, RegexOptions.IgnoreCase);
									attributeMatch = attributeRegex.Match(entry);

									if (attributeMatch.Success)
									{
										try
										{
											attributes.Charisma = Convert.ToInt32(attributeMatch.Groups["Value"].Value);
										}
										catch (FormatException)
										{
											attributes.Charisma = 0;
										}
									}
								}
								else if (identifier == "Feats")
								{
									foreach (string feat in entry.Split(','))
									{
										attributes.Feats.Add(feat.Trim());
									}

									if (attributes.WeaponFinesse)
									{
										foreach (Model.AttackSet attackSet in attributes.AttackSets)
										{
											foreach (Model.Attack attack in attackSet.Attacks)
											{
												attack.Ability = Types.Ability.Dexterity;
											}
										}
									}
								}
								else if (identifier == "Challenge Rating")
								{
									if (numbers.Count == 2)
									{
										attributes.ChallengeRating = numbers[0] / numbers[1];
									}
									else if (numbers.Count == 1)
									{
										attributes.ChallengeRating = numbers[0];
									}
									else
									{
										attributes.ChallengeRating = 1;
									}
								}
							}
						}
					}
				}
				catch (FormatException e)
				{
					MessageBox.Show("Cannot parse:" + e.Message + "\n" + currentLine);
					throw e;
				}
			}

			Model.Creature creature = new Model.Creature(attributes);

			return creature;
		}

		private static Model.DamageDescriptorSet GetDamageDescriptorSetFromString(string str, string separator = null)
		{
			if (separator == null)
				separator = " ";
			string[] sep = new string[] {separator};
			var res = str.Split(sep, StringSplitOptions.None);
			Model.DamageDescriptorSet damageDescriptorSet = new Model.DamageDescriptorSet();

			foreach (string s in res)
			{
				try
				{
					damageDescriptorSet.Add(Methods.GetDamageTypeFromString(s.Trim()));
				}
				catch (FormatException)
				{
					// Format not recognised, never mind
				}
			}
			/*
			string separatorStr = separator != null ? @"(?!" + separator + @"\b)\b" : separator;
			string typePattern = separatorStr + @"[a-z]+";	
			Regex typeRegex = new Regex(typePattern, RegexOptions.IgnoreCase);
			MatchCollection typeMatches = typeRegex.Matches(str);

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
			*/
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

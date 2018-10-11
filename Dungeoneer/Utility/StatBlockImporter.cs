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
						List<int> numbers = GetNumbersFromString(splitLine[1]);
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
							creature.ArmourClass = numbers[0];
							creature.TouchArmourClass = numbers[3];
							creature.FlatFootedArmourClass = numbers[4];
						}
						else if (identifier == "Base Attack/Grapple")
						{
							creature.BaseAttackBonus = numbers[0];
						}
						else if (identifier == "Attack")
						{
							Model.Attack attack = new Model.Attack();
							attack.Name = words[0];
							attack.Modifier = numbers[0];
							attack.Type = Types.Attack.Primary;
							Model.Damage damage = new Model.Damage();
							damage.NumDice = numbers[1];
							damage.Die = Methods.GetDieTypeFromInt(numbers[2]);
							damage.Modifier = numbers[3];
							attack.Damages.Add(damage);
							if (words[5] == "plus")
							{
								Model.Damage additionalDamage = new Model.Damage();
								additionalDamage.NumDice = numbers[4];
								additionalDamage.Die = Methods.GetDieTypeFromInt(numbers[5]);
								additionalDamage.DamageDescriptorSet.Add(Methods.GetDamageTypeFromString(words[7]));
								attack.Damages.Add(additionalDamage);
							}

							Model.AttackSet standardAttack = new Model.AttackSet
							{
								Name = "Standard Attack",
							};

							standardAttack.Attacks.Add(attack);

							creature.AttackSets.Add(standardAttack);
						}
						else if (identifier == "Full Attack")
						{
							string[] attackStrings = splitLine[1].Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries);

							foreach (string attackStr in attackStrings)
							{
								List<int> nums = GetNumbersFromString(attackStr);

								string[] splitAttackStr = attackStr.Split(' ');
								int numAttacks = 1;
								if (int.TryParse(splitAttackStr[0], out int n))
								{
									numAttacks = n;
									nums.RemoveAt(0);
								}

								int attackMod = nums[0];
								int numDice = nums[1];
								int dieType = nums[2];
								int damageMod = nums[3];

								
								
							}
							Model.Attack attack = new Model.Attack();
							attack.Name = words[0];
							attack.Modifier = numbers[0];
							attack.Type = Types.Attack.Primary;
							Model.Damage damage = new Model.Damage();
							damage.NumDice = numbers[1];
							damage.Die = Methods.GetDieTypeFromInt(numbers[2]);
							damage.Modifier = numbers[3];
							attack.Damages.Add(damage);
							if (words[5] == "plus")
							{
								Model.Damage additionalDamage = new Model.Damage();
								additionalDamage.NumDice = numbers[4];
								additionalDamage.Die = Methods.GetDieTypeFromInt(numbers[5]);
								additionalDamage.DamageDescriptorSet.Add(Methods.GetDamageTypeFromString(words[7]));
							}

							Model.AttackSet fullAttack = new Model.AttackSet
							{
								Name = "Full Attack",
							};

							fullAttack.Attacks.Add(attack);

							creature.AttackSets.Add(fullAttack);
						}
						else if (identifier == "Space/Reach")
						{

						}
						else if (identifier == "Special Attacks")
						{

						}
						else if (identifier == "Special Qualities")
						{

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

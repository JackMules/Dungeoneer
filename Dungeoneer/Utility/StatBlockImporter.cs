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
			List<int> numbers = null;
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
						if (identifier == "Size/Type")
						{
							string[] words = splitLine[1].Split(' ');
							creature.Size = Methods.GetSizeFromString(words[0]);
							words = words.Skip(1).ToArray();
							creature.Type = string.Join(" ", words);
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
							string[] tokens = splitLine[1].Split(' ');
							Model.Attack attack = new Model.Attack();
							attack.Name = tokens[0];
							attack.Modifier = numbers[0];
							attack.Type = Types.Attack.Primary;
							Model.Damage damage = new Model.Damage();
							damage.NumDice = numbers[1];
							damage.Die = Methods.GetDieTypeFromInt(numbers[2]);
							damage.Modifier = numbers[3];
							attack.Damages.Add(damage);
							if (tokens[5] == "plus")
							{
								Model.Damage additionalDamage = new Model.Damage();
								additionalDamage.NumDice = numbers[4];
								additionalDamage.Die = Methods.GetDieTypeFromInt(numbers[5]);
								additionalDamage.DamageDescriptorSet.Add(Methods.GetDamageTypeFromString(tokens[7]));
							}
						}
						else if (identifier == "Full Attack")
						{
							string[] tokens = splitLine[1].Split(' ');
							Model.Attack attack = new Model.Attack();
							attack.Name = tokens[0];
							attack.Modifier = numbers[0];
							attack.Type = Types.Attack.Primary;
							Model.Damage damage = new Model.Damage();
							damage.NumDice = numbers[1];
							damage.Die = Methods.GetDieTypeFromInt(numbers[2]);
							damage.Modifier = numbers[3];
							attack.Damages.Add(damage);
							if (tokens[5] == "plus")
							{
								Model.Damage additionalDamage = new Model.Damage();
								additionalDamage.NumDice = numbers[4];
								additionalDamage.Die = Methods.GetDieTypeFromInt(numbers[5]);
								additionalDamage.DamageDescriptorSet.Add(Methods.GetDamageTypeFromString(tokens[7]));
							}
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
	}
}

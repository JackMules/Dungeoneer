using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dungeoneer.View
{
	/// <summary>
	/// Interaction logic for DamageTypeSelector.xaml
	/// </summary>
	public partial class DamageTypeSelector : UserControl
	{
		public DamageTypeSelector()
		{
			InitializeComponent();
		}
		/*
		public static readonly DependencyProperty AcidProperty =
				DependencyProperty.Register("AcidProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Acid
		{
			get { return (string)GetValue(AcidProperty); }
			set { SetValue(AcidProperty, value); }
		}

		public static readonly DependencyProperty AdamantineProperty =
				DependencyProperty.Register("AdamantineProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Adamantine
		{
			get { return (string)GetValue(AdamantineProperty); }
			set { SetValue(AdamantineProperty, value); }
		}

		public static readonly DependencyProperty BludgeoningProperty =
				DependencyProperty.Register("BludgeoningProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Bludgeoning
		{
			get { return (string)GetValue(BludgeoningProperty); }
			set { SetValue(BludgeoningProperty, value); }
		}

		public static readonly DependencyProperty ChaosProperty =
				DependencyProperty.Register("ChaosProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Chaos
		{
			get { return (string)GetValue(ChaosProperty); }
			set { SetValue(ChaosProperty, value); }
		}

		public static readonly DependencyProperty ColdProperty =
				DependencyProperty.Register("ColdProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Cold
		{
			get { return (string)GetValue(ColdProperty); }
			set { SetValue(ColdProperty, value); }
		}

		public static readonly DependencyProperty ColdIronProperty =
				DependencyProperty.Register("ColdIronProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string ColdIron
		{
			get { return (string)GetValue(ColdIronProperty); }
			set { SetValue(ColdIronProperty, value); }
		}

		public static readonly DependencyProperty DivineProperty =
				DependencyProperty.Register("DivineProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Divine
		{
			get { return (string)GetValue(DivineProperty); }
			set { SetValue(DivineProperty, value); }
		}

		public static readonly DependencyProperty ElectricityProperty =
				DependencyProperty.Register("ElectricityProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Electricity
		{
			get { return (string)GetValue(ElectricityProperty); }
			set { SetValue(ElectricityProperty, value); }
		}

		public static readonly DependencyProperty EpicProperty =
				DependencyProperty.Register("EpicProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Epic
		{
			get { return (string)GetValue(EpicProperty); }
			set { SetValue(EpicProperty, value); }
		}

		public static readonly DependencyProperty EvilProperty =
				DependencyProperty.Register("EvilProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Evil
		{
			get { return (string)GetValue(EvilProperty); }
			set { SetValue(EvilProperty, value); }
		}

		public static readonly DependencyProperty FireProperty =
				DependencyProperty.Register("FireProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Fire
		{
			get { return (string)GetValue(FireProperty); }
			set { SetValue(FireProperty, value); }
		}

		public static readonly DependencyProperty ForceProperty =
				DependencyProperty.Register("ForceProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Force
		{
			get { return (string)GetValue(ForceProperty); }
			set { SetValue(ForceProperty, value); }
		}

		public static readonly DependencyProperty GoodProperty =
				DependencyProperty.Register("GoodProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Good
		{
			get { return (string)GetValue(GoodProperty); }
			set { SetValue(GoodProperty, value); }
		}

		public static readonly DependencyProperty LawProperty =
				DependencyProperty.Register("LawProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Law
		{
			get { return (string)GetValue(LawProperty); }
			set { SetValue(LawProperty, value); }
		}

		public static readonly DependencyProperty MagicProperty =
				DependencyProperty.Register("MagicProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Magic
		{
			get { return (string)GetValue(MagicProperty); }
			set { SetValue(MagicProperty, value); }
		}

		public static readonly DependencyProperty NegativeEnergyProperty =
				DependencyProperty.Register("NegativeEnergyProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string NegativeEnergy
		{
			get { return (string)GetValue(NegativeEnergyProperty); }
			set { SetValue(NegativeEnergyProperty, value); }
		}

		public static readonly DependencyProperty PiercingProperty =
				DependencyProperty.Register("PiercingProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Piercing
		{
			get { return (string)GetValue(PiercingProperty); }
			set { SetValue(PiercingProperty, value); }
		}

		public static readonly DependencyProperty PositiveEnergyProperty =
				DependencyProperty.Register("PositiveEnergyProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string PositiveEnergy
		{
			get { return (string)GetValue(PositiveEnergyProperty); }
			set { SetValue(PositiveEnergyProperty, value); }
		}

		public static readonly DependencyProperty SilverProperty =
				DependencyProperty.Register("SilverProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Silver
		{
			get { return (string)GetValue(SilverProperty); }
			set { SetValue(SilverProperty, value); }
		}

		public static readonly DependencyProperty SlashingProperty =
				DependencyProperty.Register("SlashingProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Slashing
		{
			get { return (string)GetValue(SlashingProperty); }
			set { SetValue(SlashingProperty, value); }
		}

		public static readonly DependencyProperty SonicProperty =
				DependencyProperty.Register("SonicProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Sonic
		{
			get { return (string)GetValue(SonicProperty); }
			set { SetValue(SonicProperty, value); }
		}

		public static readonly DependencyProperty SubdualProperty =
				DependencyProperty.Register("SubdualProperty", typeof(bool), typeof(DamageTypeSelector), new UIPropertyMetadata(String.Empty));
		public string Subdual
		{
			get { return (string)GetValue(SubdualProperty); }
			set { SetValue(SubdualProperty, value); }
		}

	*/
	}
}

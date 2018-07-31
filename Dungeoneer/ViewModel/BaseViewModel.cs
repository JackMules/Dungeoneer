using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// The property changed event.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		public virtual void NotifyPropertyChanged(string propertyName)
		{
			//  Store the event handler - in case it changes between
			//  the line to check it and the line to fire it.
			PropertyChangedEventHandler propertyChanged = PropertyChanged;

			//  If the event has been subscribed to, fire it.
			if (propertyChanged != null)
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

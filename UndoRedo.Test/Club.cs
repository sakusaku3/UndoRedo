using System.Collections.Generic;
using System.Linq;

namespace UndoRedo.Test
{
	class Club
	{
		public List<Person> Members { get; } 

		public Club() : this(new Person[0]) { }

		public Club(params Person[] members)
		{
			this.Members = members.ToList();
		}
	}
}

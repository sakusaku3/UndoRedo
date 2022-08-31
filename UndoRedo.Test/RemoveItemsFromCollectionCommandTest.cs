using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UndoRedo.Test
{
	class RemoveItemsFromCollectionCommandTest
	{
        [Test]
        public void UndoRedoTest()
        {
			var baseball = new Club(
				new Person("Takeshi", 12),
				new Person("Yamato", 13),
				new Person("Iori", 11));

			var newMember1 = new Person("Daigoro", 54);
			var newMember2 = new Person("Taro", 57);

			var newMembers = new List<Person>()
			{
				newMember1,
				newMember2,
			};

			baseball.Members.AddRange(newMembers);

			var command = new RemoveItemsFromCollectionCommand<Person>(
				baseball.Members, newMembers);

			command.Execute();
			baseball.Members.Contains(newMember1).IsFalse();
			baseball.Members.Contains(newMember2).IsFalse();

			command.Undo();
			baseball.Members[3].Is(newMember1);
			baseball.Members[4].Is(newMember2);

			command.Redo();
			baseball.Members.Contains(newMember1).IsFalse();
			baseball.Members.Contains(newMember2).IsFalse();
        }
	}
}

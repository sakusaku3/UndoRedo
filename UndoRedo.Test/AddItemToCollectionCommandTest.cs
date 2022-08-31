using NUnit.Framework;

namespace UndoRedo.Test
{
	class AddItemToCollectionCommandTest
	{
        [Test]
        public void UndoRedoTest()
        {
			var baseball = new Club(
				new Person("Takeshi", 12),
				new Person("Yamato", 13),
				new Person("Iori", 11));

			var newMember = new Person("Daigoro", 54);

			var command = new AddItemToCollectionCommand<Person>(
				baseball.Members, newMember);

			command.Execute();
			baseball.Members[3].Is(newMember);

			command.Undo();
			baseball.Members.Contains(newMember).IsFalse();

			command.Redo();
			baseball.Members[3].Is(newMember);
        }
	}
}

using NUnit.Framework;

namespace UndoRedo.Test
{
	class SetValueCommandTest
	{
        [Test]
        public void UndoRedoTest()
        {
			var takeshi = new Person("Takeshi", 12);

			var command = new SetValueCommand<int>(takeshi.Age, 13, x => takeshi.Age = x);

			command.Execute();
			takeshi.Age.Is(13);

			command.Undo();
			takeshi.Age.Is(12);

			command.Redo();
			takeshi.Age.Is(13);
        }
	}
}

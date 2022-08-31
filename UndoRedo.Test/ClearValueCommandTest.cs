using NUnit.Framework;

namespace UndoRedo.Test
{
	class ClearValueCommandTest
	{
        [Test]
        public void UndoRedoTest()
        {
			var takeshi = new Person("Takeshi", 12);

			var command = new ClearValueCommand<int>(takeshi.Age, x => takeshi.Age = x);

			command.Execute();
			takeshi.Age.Is(0);

			command.Undo();
			takeshi.Age.Is(12);

			command.Redo();
			takeshi.Age.Is(0);
        }
	}
}

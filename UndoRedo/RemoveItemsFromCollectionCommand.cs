using System.Collections.Generic;
using System.Linq;

namespace UndoRedo
{
	public class RemoveItemsFromCollectionCommand<T> : IUndoableCommand
	{
		private readonly SequentialCommand commands; 

		public RemoveItemsFromCollectionCommand(
			IList<T> collection,
			IEnumerable<T> items)
		{
			this.commands = new SequentialCommand(
				items.Select(x => new RemoveItemFromCollectionCommand<T>(collection, x)));
		}

		public void Execute() => this.commands.Execute();
		public void Undo() => this.commands.Undo();
		public void Redo() => this.commands.Redo();
	}
}

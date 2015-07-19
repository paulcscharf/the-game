using Bearded.Utilities.Collections;
using Bearded.Utilities.SpaceTime;

namespace Game
{
    abstract class GameObject : IDeletable
    {
        protected readonly GameState game;

        public bool Deleted { get; private set; }

        protected GameObject(GameState game)
        {
            this.game = game;

            game.Add(this);
        }

        public abstract void Update(TimeSpan elapsedTime);

        public abstract void Draw();

        protected virtual void onDelete()
        {
            
        }

        public void Delete()
        {
            this.onDelete();
            this.Deleted = true;
        }

    }
}
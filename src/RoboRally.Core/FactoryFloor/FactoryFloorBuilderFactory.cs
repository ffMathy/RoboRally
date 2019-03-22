using System;

namespace RoboRally.Core.FactoryFloor
{
    [Serializable]
    class FactoryFloorBuilderFactory : IFactoryFloorBuilderFactory
	{
		private readonly IGame _game;

		public FactoryFloorBuilderFactory(IGame game)
		{
			_game = game;
		}

		public IFactoryFloorBuilder Create(int width, int height)
		{
			return new FactoryFloorBuilder(_game, width, height);
		}
	}
}

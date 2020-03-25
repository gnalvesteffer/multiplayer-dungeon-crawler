import Direction from '../models/direction';
import Game from '../index';
import assetManifest from '../../../assets/asset-manifest';

export default class MapContext {
  constructor() {
    this.game = Game.instance;
  }

  getEnvironmentAssetData = () => {
    const environmentId = this.game.state.map.environmentId;
    return assetManifest.environments.find(environment => environment.id === environmentId);
  };

  getGroundTexturePath = () => {
    return this.getEnvironmentAssetData().ground_texture_path;
  };

  getSkyTexturePath = () => {
    const environmentAssetData = this.getEnvironmentAssetData();
    const direction = this.game.context.player.getDirection();
    switch (direction) {
      case Direction.Values.NORTH:
        return environmentAssetData.sky_north_texture_path;
      case Direction.Values.EAST:
        return environmentAssetData.sky_east_texture_path;
      case Direction.Values.SOUTH:
        return environmentAssetData.sky_south_texture_path;
      case Direction.Values.WEST:
        return environmentAssetData.sky_west_texture_path;
    }
  };
}
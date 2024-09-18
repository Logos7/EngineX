using EngineX.Daemons;
using EngineX.Objects;

namespace EngineX
{
    public class World
    {
        public List<ADaemon> daemons;
        public List<Scene3D> scenes;

        public Scene3D currentScene;

        public World() : this(new Scene3D()) { }

        public World(Scene3D aCurrentScene)
        {
            daemons = new List<ADaemon>();
            scenes = new List<Scene3D>();

            currentScene = aCurrentScene;

            scenes.Add(currentScene);
        }

        public void Update()
        {

        }
    }
}

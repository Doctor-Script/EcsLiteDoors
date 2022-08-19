using UnityEngine;

namespace EcsLiteDoors
{
    public class ViewsFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private ButtonView _buttonPrefab;
        [SerializeField] private DoorView _doorPrefab;

        public DoorView InstantiateDoor(Vector2 position, uint color)
        {
            var doorView = Instantiate(_doorPrefab);
            doorView.Init(position, color);
            return doorView;
        }
        
        public ButtonView InstantiateButton(Vector2 position, uint color)
        {
            var buttonView = Instantiate(_buttonPrefab);
            buttonView.Init(position, color);
            return buttonView;
        }

        public GameObject InstantiatePlayer(Vector2 position)
        {
            var player = Instantiate(_playerPrefab);
            player.transform.position = position.ToVector3();
            return player;
        }
    }
}

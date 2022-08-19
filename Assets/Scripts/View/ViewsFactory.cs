using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcsLiteDoors
{
    public class ViewsFactory : MonoBehaviour
    {
        [SerializeField] private ButtonView _buttonPrefab;
        [SerializeField] private DoorView _doorPrefab;

        public DoorView InstantiateDoor(Vector3 position, uint color)
        {
            var doorView = Instantiate(_doorPrefab);
            doorView.Init(position, color);
            return doorView;
        }
        
        public ButtonView InstantiateButton(Vector3 position, uint color)
        {
            var buttonView = Instantiate(_buttonPrefab);
            buttonView.Init(position, color);
            return buttonView;
        }
    }
}

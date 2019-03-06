namespace Items
{
    public class Key : ItemBase
    {
        protected override void OnPickup()
        {
            _playerBase.PickUpKey();
            Destroy(gameObject);
        }
    }
}
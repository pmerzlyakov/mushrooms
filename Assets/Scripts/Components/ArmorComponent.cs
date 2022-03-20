namespace Mushrooms
{
    public struct ArmorComponent
    {
        public string Name;
        public int Damage;
        public int Radius;
        
        public enum ArmorType
        {
            Weapon = 0,
            Defense = 1
        }  
    }
}
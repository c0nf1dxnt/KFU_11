namespace Part1
{
    class BuildingArray
    {
        private Building[] buildingsArray = new Building[10];

        public void AddBuilding(Building building)
        {
            buildingsArray[building.BuildingNumber - 1] = building;
        }
        public Building[] BuildingsArray
        {
            get
            {
                return buildingsArray;
            }
        }
        public Building this[int index]
        {
            get
            {
                return buildingsArray[index];
            }
        }
    }
}

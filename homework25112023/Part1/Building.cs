namespace Part1
{
    public class Building
    {
        private int buildingNumber;
        private int height;
        private int floors;
        private int apartments;
        private int entrances;
        private static int lastBuildingNumber = 0;

        public Building(int height, int floors, int apartments, int entrances)
        {
            buildingNumber = GenerateBuildingNumber();
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }

        public int BuildingNumber
        {
            get
            {
                return buildingNumber;
            }
            set
            {
                buildingNumber = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int Floors
        {
            get
            {
                return floors;
            }
            set
            {
                floors = value;
            }
        }
        public int Apartments
        {
            get
            {
                return apartments;
            }
            set
            {
                apartments = value;
            }
        }
        public int Entrances
        {
            get
            {
                return entrances;
            }
            set
            {
                entrances = value;
            }
        }
        private static int GenerateBuildingNumber()
        {
            return ++lastBuildingNumber;
        }

        public double CalculateFloorHeight()
        {
            return (double)height / floors;
        }

        public int CalculateApartmentsPerEntrance()
        {
            return apartments / entrances;
        }

        public int CalculateApartmentsPerFloor()
        {
            return apartments / floors;
        }
        public override string ToString()
        {
            return $"\nНомер здания: {buildingNumber},\nВысота: {height}\nКоличество этажей: {floors}\nКоличество квартир: {apartments}" +
                $"\nКоличество подъездов: {entrances}\nВысота одного этажа: {CalculateFloorHeight()}\nКоличество квартир в одном подъезде: " +
                $"{CalculateApartmentsPerEntrance()}\nКоличество квартир на этаже: {CalculateApartmentsPerFloor()}\n";
        }
    }
}

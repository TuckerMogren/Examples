using InheritancePlayground.Domain.Interfaces;

namespace InheritancePlayground.Domain.SessionModels
{
    public class HouseholdDto : IHouseholdDto
    {
        public IReadOnlyCollection<HomeDto> Homes => _homes;
        public IReadOnlyCollection<AdultDto> Adults => _adults;
        public IReadOnlyCollection<ChildDto> Children => _children;
        public IReadOnlyCollection<PetDto> Pets => _pets;

        private readonly List<HomeDto> _homes;
        private readonly List<AdultDto> _adults;
        private readonly List<ChildDto> _children;
        private readonly List<PetDto> _pets;

        public HouseholdDto()
        {
            _homes = [];
            _adults = [];
            _children = [];
            _pets = [];
        }

        public bool AddHome(HomeDto home)
        {
            if (home == null) return false;

            try{
                _homes.Add(home);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool AddAdult(AdultDto adult)
        {
            if (adult == null) return false;

            try{
                _adults.Add(adult);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool AddChild(ChildDto child)
        {
            if (child == null) return false;

            try{
                _children.Add(child);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool AddPet(PetDto pet)
        {
            if (pet == null) return false;

            try{
                _pets.Add(pet);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}
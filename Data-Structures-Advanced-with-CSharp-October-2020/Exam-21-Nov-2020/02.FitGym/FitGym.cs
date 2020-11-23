namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        Dictionary<int, Member> membersById = new Dictionary<int, Member>();
        Dictionary<int, Trainer> trainersById = new Dictionary<int, Trainer>();
        Dictionary<Trainer, HashSet<Member>> trainersWithMembers = new Dictionary<Trainer, HashSet<Member>>();
        Dictionary<Member, Trainer> membersTrainer = new Dictionary<Member, Trainer>();

        public void AddMember(Member member)
        {
            if (this.Contains(member))
            {
                throw new ArgumentException();
            }

            this.membersById[member.Id] = member;
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.Contains(trainer))
            {
                throw new ArgumentException();
            }

            this.trainersById[trainer.Id] = trainer;
            this.trainersWithMembers[trainer] = new HashSet<Member>();
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.Contains(trainer))
            {
                throw new ArgumentException();
            }

            if (this.membersTrainer.ContainsKey(member))
            {
                throw new ArgumentException();
            }

            if (!this.Contains(member))
            {
                this.membersById[member.Id] = member;
            }

            this.membersTrainer[member] = trainer;
            this.trainersWithMembers[trainer].Add(member);
        }

        public bool Contains(Member member)
        {
            return this.membersById.ContainsKey(member.Id);
        }

        public bool Contains(Trainer trainer)
        {
            return this.trainersById.ContainsKey(trainer.Id);
        }

        public Trainer FireTrainer(int id)
        {
            if (!this.trainersById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            var toRemove = this.trainersById[id];
            this.trainersById.Remove(id);

            var membersOfTheTrainer = this.trainersWithMembers[toRemove];
            foreach (var member in membersOfTheTrainer)
            {
                this.membersTrainer.Remove(member);
            }

            this.trainersWithMembers.Remove(toRemove);

            return toRemove;
        }

        public Member RemoveMember(int id)
        {
            if (!this.membersById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            var toRemove = this.membersById[id];

            this.membersById.Remove(id);


            if (this.membersTrainer.ContainsKey(toRemove))
            {
                var trainerOfTheMember = this.membersTrainer[toRemove];
                if (trainerOfTheMember != null)
                {
                    this.trainersWithMembers[trainerOfTheMember].Remove(toRemove);
                }
                this.membersTrainer.Remove(toRemove);
            }

            return toRemove;
        }

        public int MemberCount
        {
            get => this.membersById.Count;
        }

        public int TrainerCount
        {
            get => this.trainersById.Count;
        }

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            var found = this.membersById.Values
                .OrderBy(x => x.RegistrationDate)
                .ThenByDescending(x => x.Name)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Member>();
            }

            return found;
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            var found = this.trainersById.Values
                .OrderBy(x => x.Popularity)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Trainer>();
            }

            return found;
        }

        public IEnumerable<Member>
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            var found = this.trainersWithMembers[trainer]
                .OrderBy(x => x.RegistrationDate)
                .ThenBy(x => x.Name)
                .ToList();

            if (found.Count == 0)
            {
                return Enumerable.Empty<Member>();
            }

            return found;
        }

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            var found = new List<Member>();

            var trainers = this.trainersById.Values
                .Where(x => x.Popularity >= lo
                            && x.Popularity <= hi)
                .ToList();

            foreach (var trainer in trainers)
            {
                foreach (var member in this.trainersWithMembers[trainer])
                {
                    found.Add(member);
                }
            }

            if (found.Count == 0)
            {
                return Enumerable.Empty<Member>();
            }

            return found
                .OrderBy(x => x.Visits)
                .ThenBy(x => x.Name)
                .ToList();
        }

        public Dictionary<Trainer, HashSet<Member>>
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            var found = this.trainersWithMembers
                .OrderBy(x => x.Value.Count)
                .ThenBy(x => x.Key.Popularity)
                .ToDictionary(x => x.Key, x => x.Value);

            return found;
        }
    }
}
namespace _02.FitGym
{
    using System.Collections.Generic;

    public interface IGym
    {
        void AddMember(Member member);

        void HireTrainer(Trainer trainer);

        void Add(Trainer trainer, Member member);

        bool Contains(Member member);

        bool Contains(Trainer trainer);

        Trainer FireTrainer(int id);

        Member RemoveMember(int id);

        int MemberCount { get; }

        int TrainerCount { get; }

        IEnumerable<Member> GetMembersInOrderOfRegistrationAscendingThenByNamesDescending();

        IEnumerable<Trainer> GetTrainersInOrdersOfPopularity();

        IEnumerable<Member> GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer);

        IEnumerable<Member> GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi);

        Dictionary<Trainer, HashSet<Member>> GetTrainersAndMemberOrderedByMembersCountThenByPopularity();
    }
}
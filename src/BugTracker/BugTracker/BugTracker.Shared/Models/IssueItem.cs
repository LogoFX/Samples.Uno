using System;

namespace BugTracker.Shared.Models
{
    public class IssueItem : AppModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private IssueType _kind;
        public IssueType Kind
        {
            get => _kind;
            set => SetProperty(ref _kind, value);
        }

        private IssueStatus _status;
        public IssueStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private int _effort;
        public int Effort
        {
            get => _effort;
            set => SetProperty(ref _effort, value);
        }

        private DateTimeOffset _createdAt = DateTimeOffset.Now.ToLocalTime();
        public DateTimeOffset CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }

        private DateTimeOffset? _startedAt;
        public DateTimeOffset? StartedAt
        {
            get => _startedAt;
            set => SetProperty(ref _startedAt, value);
        }

        private DateTimeOffset? _completedAt;
        public DateTimeOffset? CompletedAt
        {
            get => _completedAt;
            set => SetProperty(ref _completedAt, value);
        }
    }

    public enum IssueType
    {
        Bug,
        Issue,
        Task,
        Feature
    }

    public enum IssueStatus
    {
        Icebox,
        Planned,
        Wip,
        Done,
        Removed
    }
}

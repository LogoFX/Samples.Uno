﻿using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BugTracker.Shared.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BugTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static readonly DependencyProperty IssueItemProperty =
            DependencyProperty.Register(nameof(Item), typeof(IssueItem), typeof(MainPage), new PropertyMetadata(default(IssueItem)));

        public MainPage()
        {
            this.InitializeComponent();
        }

        public IssueItem Item
        {
            get => (IssueItem)GetValue(IssueItemProperty);
            set => SetValue(IssueItemProperty, value);
        }

        public IssueStatus[] StatusList => new[]
        {
            IssueStatus.Icebox,
            IssueStatus.Planned,
            IssueStatus.Wip,
            IssueStatus.Done,
            IssueStatus.Removed
        };

        public IssueType[] IssueTypeList => new[]
        {
            IssueType.Bug,
            IssueType.Feature,
            IssueType.Issue,
            IssueType.Task
        };

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Item = new IssueItem
            {
                Title = "Getting Started",
                Description = @"Create a page to enter Issues that we need to work on.

## Acceptance Criteria

- Display the issue Id
- Provide an ability to select the issue Type (i.e. Bug, Feature, etc)
- Include an Issue Title
- Include a full issue description with support for Markdown
- Include an issue effort
- Include an ability for a developer to update the Status (i.e Icebox, WIP, etc)

## Additional Comments

We would like to have a visual indicator for the type of issue as well as something to visualize the effort involved",
                Effort = 3,
                Status = IssueStatus.Wip,
                Kind = IssueType.Feature,
                CreatedAt = new DateTimeOffset(2019, 04, 03, 08, 0, 0, TimeSpan.FromHours(-8)),
                StartedAt = new DateTimeOffset(2019, 04, 30, 08, 0, 0, TimeSpan.FromHours(-8))
            };
        }

        // Sets the time when we Complete or Start an issue.
        private void StatusPicker_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            switch (Item.Status)
            {
                case IssueStatus.Removed:
                case IssueStatus.Done:
                    if (Item.CompletedAt is null)
                        Item.CompletedAt = DateTimeOffset.Now.ToLocalTime();
                    break;
                case IssueStatus.Wip:
                    if (Item.StartedAt is null)
                        Item.StartedAt = DateTimeOffset.Now.ToLocalTime();
                    break;
                default:
                    Item.StartedAt = null;
                    Item.CompletedAt = null;
                    break;
            }
        }

        // Provides a unique color based on the type of Issue
        private void IssueType_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var color = Colors.Red;
            switch (IssueTypeBox.SelectedItem)
            {
                case IssueType.Feature:
                    color = Colors.Green;
                    break;
                case IssueType.Issue:
                    color = Colors.Blue;
                    break;
                case IssueType.Task:
                    color = Colors.Yellow;
                    break;
            }
            IssueTypeIndicator.Background = new SolidColorBrush(color);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int votesCount = 0;
        Dictionary<string, int> votes;
        public MainWindow()
        {
            InitializeComponent();
            QuestionTextBlock.Text = "Wolisz A, B, C czy D?";
            votes = new Dictionary<string, int>()
            {
                { "A",0},
                { "B",0},
                { "C",0},
                { "D",0}
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var choice = button.Content.ToString();
            votes[choice]++;
            votesCount++;

            AllVotes.Text = votesCount.ToString();
            RedrawGraph();
        }

        private void RedrawGraph()
        {
            var maxHeight = Canvas.ActualHeight;

            RA.Height = maxHeight * (votes["A"] / (double)votesCount);
            RB.Height = maxHeight * (votes["B"] / (double)votesCount);
            RC.Height = maxHeight * (votes["C"] / (double)votesCount);
            RD.Height = maxHeight * (votes["D"] / (double)votesCount);

            Stat2.Text = votes
                .Max(x => x.Value)
                .ToString();
                
        }
    }
}

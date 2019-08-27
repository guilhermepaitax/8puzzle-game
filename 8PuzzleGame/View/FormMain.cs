using _8PuzzleGame.Controllers;
using _8PuzzleGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8PuzzleGame
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            int[,] initState = GenerateInitState();
            int[,] goalState = GenerateGoalState();

            NodeTree tree = new NodeTree(initState);
            SearchController searchController = new SearchController();

            List<NodeTree> solution = searchController.FirstSearch(tree, goalState);

            if (solution.Count > 0)
            {
                solution.Reverse();
                for (int i = 0; i < solution.Count; i++)
                {
                    PrintNode(solution[i].puzzle);
                }
            }
        }

        private int[,] GenerateInitState()
        {
            int[,] initState = new int[3, 3];
            initState[0, 0] = (int)numUD00.Value;
            initState[0, 1] = (int)numUD01.Value;
            initState[0, 2] = (int)numUD02.Value;

            initState[1, 0] = (int)numUD10.Value;
            initState[1, 1] = (int)numUD11.Value;
            initState[1, 2] = (int)numUD12.Value;

            initState[2, 0] = (int)numUD20.Value;
            initState[2, 1] = (int)numUD21.Value;
            initState[2, 2] = (int)numUD22.Value;

            return initState;
        }

        private int[,] GenerateGoalState()
        {
            int[,] goalState = new int[3, 3];
            goalState[0, 0] = (int)numUDF00.Value;
            goalState[0, 1] = (int)numUDF01.Value;
            goalState[0, 2] = (int)numUDF02.Value;

            goalState[1, 0] = (int)numUDF10.Value;
            goalState[1, 1] = (int)numUDF11.Value;
            goalState[1, 2] = (int)numUDF12.Value;

            goalState[2, 0] = (int)numUDF20.Value;
            goalState[2, 1] = (int)numUDF21.Value;
            goalState[2, 2] = (int)numUDF22.Value;

            return goalState;
        }

        private void PrintNode(int[,] node)
        {
            richTextBoxResult.AppendText(Environment.NewLine);
            richTextBoxResult.AppendText(node[0,0].ToString() + " " + node[0, 1].ToString() + " " +
                node[0, 2].ToString() + "\n");
            richTextBoxResult.AppendText(node[1, 0].ToString() + " " + node[1, 1].ToString() + " " +
                node[1, 2].ToString() + "\n");
            richTextBoxResult.AppendText(node[2, 0].ToString() + " " + node[2, 1].ToString() + " " +
                node[2, 2].ToString() + "\n");
        }
    }
}

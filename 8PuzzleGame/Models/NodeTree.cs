using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzleGame.Models
{
    class NodeTree
    {
        public List<NodeTree> children = new List<NodeTree>();
        public NodeTree parent = null;
        public int[,] puzzle = new int[3, 3];
        int[,] goalPuzzle = new int[3,3];
        int LineIndex = 0;
        int ColIndex = 0;

        public NodeTree(int[,] initSatate, int[,] goalState)
        {
            //Array.Copy(puzzle, initSatate, initSatate.Length);
            //Array.Copy(goalPuzzle, goalState, goalState.Length);
            puzzle = (int[,])initSatate.Clone();
            goalPuzzle = (int[,])goalState.Clone();
        }

        public NodeTree(int[,] p)
        {
            //Array.Copy(puzzle, p, p.Length);
            puzzle = (int[,])p.Clone();
        }

        public void SideMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzle[i, j] == 0)
                    {
                        LineIndex = i;
                        ColIndex = j;
                    }
                }
            }

            MoveToRight(puzzle, LineIndex, ColIndex);
            MoveToLeft(puzzle, LineIndex, ColIndex);
            MoveToUp(puzzle, LineIndex, ColIndex);
            MoveToDown(puzzle, LineIndex, ColIndex);
        }

        public void MoveToRight(int[,] currentPuzze, int LineIndex, int ColIndex)
        {
            if(ColIndex < 2)
            {
                int[,] subPuzzle = new int[3, 3];
                //Array.Copy(subPuzzle, currentPuzze, currentPuzze.Length);
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex + 1, ColIndex];
                subPuzzle[LineIndex + 1, ColIndex] = subPuzzle[LineIndex, ColIndex];
                subPuzzle[LineIndex, ColIndex] = temp;

                NodeTree child = new NodeTree(subPuzzle);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToLeft(int[,] currentPuzze, int LineIndex, int ColIndex)
        {
            if (ColIndex > 0)
            {
                int[,] subPuzzle = new int[3, 3];
                //Array.Copy(subPuzzle, currentPuzze, currentPuzze.Length);
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex - 1, ColIndex];
                subPuzzle[LineIndex - 1, ColIndex] = subPuzzle[LineIndex, ColIndex];
                subPuzzle[LineIndex, ColIndex] = temp;

                NodeTree child = new NodeTree(subPuzzle);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToUp(int[,] currentPuzze, int LineIndex, int ColIndex)
        {
            if (LineIndex > 0)
            {
                int[,] subPuzzle = new int[3, 3];
                //Array.Copy(subPuzzle, currentPuzze, currentPuzze.Length);
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex, ColIndex - 1];
                subPuzzle[LineIndex, ColIndex - 1] = subPuzzle[LineIndex, ColIndex];
                subPuzzle[LineIndex, ColIndex] = temp;

                NodeTree child = new NodeTree(subPuzzle);
                children.Add(child);
                child.parent = this;
            }
        }

        public void MoveToDown(int[,] currentPuzze, int LineIndex, int ColIndex)
        {
            if (LineIndex < 2)
            {
                int[,] subPuzzle = new int[3, 3];
                //Array.Copy(subPuzzle, currentPuzze, currentPuzze.Length);
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex, ColIndex + 1];
                subPuzzle[LineIndex, ColIndex + 1] = subPuzzle[LineIndex, ColIndex];
                subPuzzle[LineIndex, ColIndex] = temp;

                NodeTree child = new NodeTree(subPuzzle);
                children.Add(child);
                child.parent = this;
            }
        }

        public bool IsSamePuzzle(int[,] p)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzle[i, j] != p[i, j]) return false;
                }
            }
            return true;
        }

        public bool IsTheGoal()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (goalPuzzle[i, j] != puzzle[i, j]) return false;
                }
            }

            return true;
        }
    }
}

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
        int LineIndex = 0;
        int ColIndex = 0;

        public NodeTree(int[,] p)
        {
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
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex, ColIndex + 1];
                subPuzzle[LineIndex, ColIndex + 1] = subPuzzle[LineIndex, ColIndex];
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
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex, ColIndex - 1];
                subPuzzle[LineIndex, ColIndex - 1] = subPuzzle[LineIndex, ColIndex];
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
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex - 1, ColIndex];
                subPuzzle[LineIndex - 1, ColIndex] = subPuzzle[LineIndex, ColIndex];
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
                subPuzzle = (int[,])currentPuzze.Clone();

                int temp = subPuzzle[LineIndex + 1, ColIndex];
                subPuzzle[LineIndex + 1, ColIndex] = subPuzzle[LineIndex, ColIndex];
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

        public bool IsTheGoal(int[,] goal)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (goal[i, j] != puzzle[i, j]) return false;
                }
            }

            return true;
        }
    }
}

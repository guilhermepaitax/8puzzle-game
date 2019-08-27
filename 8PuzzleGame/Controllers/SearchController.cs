using _8PuzzleGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzleGame.Controllers
{
    class SearchController
    {
        public List<NodeTree> FirstSearch(NodeTree root)
        {
            List<NodeTree> pathSolution = new List<NodeTree>();
            List<NodeTree> openList = new List<NodeTree>();
            List<NodeTree> closeList = new List<NodeTree>();
            bool goalFound = false;

            openList.Add(root);

            while (openList.Count > 0 && !goalFound)
            {
                NodeTree currentNode = openList[0];
                closeList.Add(currentNode);
                openList.RemoveAt(0);
                currentNode.SideMove();

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    if (currentNode.IsTheGoal())
                    {
                        goalFound = true;
                        TracePath(pathSolution, currentNode);
                    }

                    if(!Contains(openList, currentNode) && !Contains(closeList, currentNode))
                    {
                        openList.Add(currentNode);
                    }
                }
            }

            return pathSolution;
        }

        public static bool Contains(List<NodeTree> list, NodeTree c)
        {
            bool contains = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsSamePuzzle(c.puzzle))
                {
                    contains = true;
                }
            }

            return contains;
        }

        public void TracePath(List<NodeTree> path, NodeTree node)
        {
            NodeTree currentNode = node;
            path.Add(currentNode);
            while (currentNode.parent != null)
            {
                currentNode = currentNode.parent;
                path.Add(currentNode);
            }
        }
    }
}

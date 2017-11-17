using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Oop
{
    public class TreeTest
    {
        private class TreeNode
        {
            public int? Id { get; set; }
            public TreeNode L { get; set; }
            public TreeNode R { get; set; }
        }

        private TreeNode BuildTree(int deep)
        {
            var node = new TreeNode();

            if (deep > 0)
            {
                node.L = BuildTree(deep - 1);
                node.R = BuildTree(deep - 1);
            }

            return node;
        }

        int x;

        private void Enumerate(TreeNode node)
        {
            if (node == null) return;
            x++;
            Enumerate(node.L);
            Enumerate(node.R);
        }

        [Fact]
        public void Run()
        {
            x = 0;
            Enumerate(BuildTree(0));
            Assert.Equal(1, x);

            x = 0;
            Enumerate(BuildTree(1));
            Assert.Equal(3, x);

            x = 0;
            Enumerate(BuildTree(2));
            Assert.Equal(7, x);


            x = 0;
            Enumerate(BuildTree(8));

        }
    }
}

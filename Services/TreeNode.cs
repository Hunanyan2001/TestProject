namespace WebApplication1.Services
{
    public class TreeNode<T>
    {
        T value;
        TreeNode<T> parent;
        List<TreeNode<T>> children;

        public T Value
        {
            get { return value; }
        }

        public TreeNode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public IList<TreeNode<T>> Children
        {
            get { return children.AsReadOnly(); }
        }

        public TreeNode(T value, TreeNode<T> parent)
        {
            this.value = value;
            this.parent = parent;   
            children = new List<TreeNode<T>>();
        }

        public bool AddChild(TreeNode<T> child)
        {
            if(children.Contains(child) || child == this) return false;

            children.Add(child);
            child.Parent = this;
            return true;
        }

        public bool RemoveChild(TreeNode<T> child)
        {
            if (!children.Contains(child)) return false;

            child.Parent = null;
            return children.Remove(child);
        } 
    }
}

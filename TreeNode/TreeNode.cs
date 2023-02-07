using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;  // used for FindTreeNode

namespace CsiMigrationHelper
{

    public delegate void HandlerNodeCreated(object sender, EventArgsNodeCreated e);
    public delegate void HandlerEnabledStateChanged(object sender, EventArgsNodeChanged e);

    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        public event HandlerNodeCreated eventNodeCreated;
        public event HandlerEnabledStateChanged eventEnabledStateChanged;

        private bool enabled;
        public bool Enabled
        {
            get { return this.enabled; }
            set
            {
                this.eventEnabledStateChanged += new HandlerEnabledStateChanged(OnEnabledStateChanged);
                this.enabled = value;
                
                var enabledStateChanged = eventEnabledStateChanged as HandlerEnabledStateChanged;
                if (enabledStateChanged != null)
                {
                    if ((data != null) && typeof(T).Equals(typeof(DbObject)))
                    {
                        DbObject dbObject = (DbObject)Convert.ChangeType(data, typeof(DbObject));
                        if (dbObject != null)
                        {
                            enabledStateChanged(enabled, new EventArgsNodeChanged(TreeNode<DbObject>.ConvertToTreeNodeDbObject(this), value)); //this line triggers OnEnabledStateChanged()
                        }
                    }
                }
                this.eventEnabledStateChanged -= new HandlerEnabledStateChanged(OnEnabledStateChanged);

                if (this.HasChildren)
                {
                    foreach (TreeNode<T> childNode in this.Children)
                    {
                        foreach (TreeNode<T> node in childNode)
                        {
                            if ((node != null) && typeof(T).Equals(typeof(DbObject)) && node.TreeNodeLevel == this.TreeNodeLevel + 1) // set only direct Children of startingNode
                            {
                                DbObject dbObject = (DbObject)Convert.ChangeType(node.Data, typeof(DbObject));
                                if (dbObject != null)
                                {
                                    childNode.Enabled = value;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool cloneableFromSrc;
        public bool CloneableFromSrc 
        {
            get { return this.cloneableFromSrc; }
            set
            {
                this.cloneableFromSrc = value;
                if (this.HasChildren)
                {
                    foreach (TreeNode<T> childNode in this.Children)
                    {
                        foreach (TreeNode<T> node in childNode)
                        {
                            if ((node != null) && typeof(T).Equals(typeof(DbObject)) && node.TreeNodeLevel == this.TreeNodeLevel + 1) // set only direct Children of startingNode
                            {
                                DbObject dbObject = (DbObject)Convert.ChangeType(node.Data, typeof(DbObject));
                                if (dbObject != null)
                                {
                                    childNode.CloneableFromSrc = value;
                                }
                            }
                        }
                    }
                }

            }
        }

        private T data;
        public T Data
        {
            get { return this.data; } 
            set 
            {
                //this.eventDataChanged += new HandlerDataChanged(OnDataChanged);
                data = value;
                //var dataChanged = eventDataChanged as HandlerDataChanged;
                //if (dataChanged != null)
                //{
                //    if ((data != null) && typeof(T).Equals(typeof(DbObject)))
                //    {
                //        DbObject dbObject = (DbObject)Convert.ChangeType(data, typeof(DbObject));
                //        if (dbObject != null)
                //        {
                //            dataChanged(data, new EventArgsNodeCreated(dbObject, 1)); //this line triggers the execution of method(s) specified on t.eventNodeAdded in AddEventHandler()
                //        }
                //    }
                //}
                //this.eventDataChanged -= new HandlerDataChanged(OnDataChanged);
            }
        }

        public TreeNode<T> Parent { get; set; }
        public ICollection<TreeNode<T>> Children { get; set; }
        public ICollection<TreeNode<T>> Cousins { get; set; }
        public bool IsDummyNode { get; set; }

        public Boolean IsRoot
        {
            get { return this.Parent == null; }
        }

        public Boolean HasParent
        {
            get { return this.Parent != null; }
        }

        public Boolean HasChildren
        {
            get
            {
                if (this.Children != null)
                {
                    return this.Children.Count > 0;
                }
                else return false;
            }
        }

        public Boolean HasCousins
        {
            get
            {
                if (this.Cousins != null)
                {
                    return this.Cousins.Count > 0;
                }
                else return false;
            }
        }

        public Boolean IsLeaf
        {
            get
            {
                if (!this.HasChildren)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsTextSet()
        {
            DbObject dbObject = ConvertToDbObject(this);
            return dbObject.ObjectText.Length > 0 ? true : false;
        }

        public int TreeNodeLevel
        {
            get
            {
                if (this.IsRoot)
                {
                    return 0;
                }
                else if (this.HasParent)
                {
                    return Parent.TreeNodeLevel + 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int GetNumberOfChildren()
        {
            if (this.HasChildren)
            {
                return Children.Count();
            }
            else
            {
                return 0;
            }
        }

        public int GetNumberOfCousins()
        {
            if (this.HasCousins)
            {
                return Cousins.Count();
            }
            else
            {
                return 0;
            }
        }

        #region constructors:
        //public TreeNode()
        //{
        //    this.AddEventHandlerNodeCreated(this);
        //}

        public TreeNode(T data)
        {
            this.Enabled = true;
            this.Data = data;
            this.Children = new LinkedList<TreeNode<T>>();
            this.Cousins = new LinkedList<TreeNode<T>>();
            this.ElementsIndex = new LinkedList<TreeNode<T>>();
            this.ElementsIndex.Add(this);
            this.AddEventHandlerNodeCreated(this);
        }
        public TreeNode(T data, TreeNode<T> parent)
        {
            this.Enabled = true;
            this.Data = data;
            this.Parent = parent;
            this.Children = new LinkedList<TreeNode<T>>();
            this.Cousins = new LinkedList<TreeNode<T>>();
            this.ElementsIndex = new LinkedList<TreeNode<T>>();
            this.ElementsIndex.Add(this);
            this.AddEventHandlerNodeCreated(this);
        }

        public TreeNode(TreeNode<T> cousinInvitee, TreeNode<T> cousinInviting, bool cloneableFromSrc)
        {
            this.Enabled = true;
            this.Data = cousinInvitee.Data;            
            this.Parent = cousinInvitee.Parent;
            this.CloneableFromSrc = cloneableFromSrc;
            this.Children = cousinInvitee.Children; //new LinkedList<TreeNode<T>>();
            this.Cousins = new LinkedList<TreeNode<T>>();
            this.Cousins.Add(cousinInviting);            
            this.ElementsIndex = new LinkedList<TreeNode<T>>();
            this.ElementsIndex.Add(this);
            //this.AddEventHandlerCousinNodeCreated(this); // to do: define a handler that will check if node-levels for both Cousins match
        }
        #endregion

        public TreeNode<T> AddRoot(T root)
        {
            TreeNode<T> rootNode = new TreeNode<T>(root);

            this.Data = root;
            this.Children = new LinkedList<TreeNode<T>>();
            this.Cousins = new LinkedList<TreeNode<T>>();
            this.ElementsIndex = new LinkedList<TreeNode<T>>();
            this.ElementsIndex.Add(this);
            return rootNode;
        }

        public TreeNode<T> AddChild(T child)
        {
            if (child == null)
            {
                throw new Exception("Method AddChild() received a null input parameter (T child)");
            }
            TreeNode<T> childNode = new TreeNode<T>(child, this);
            if (childNode != null)
            {
                this.Children.Add(childNode);
                this.RegisterChildForSearch(childNode);
            }
            return childNode;
        }

        public TreeNode<T> AddCousin(TreeNode<T> cousin, bool isCloneableFromSrc)
        {
            if (cousin == null)
            {
                throw new Exception("Method AddCousin() received a null input parameter (T cousin)");
            }
            //TreeNode<T> cousinNode = new TreeNode<T>(cousin, this, isCloneableFromSrc);
            if (cousin != null)
            {
                this.Cousins.Add(cousin);
                this.RegisterChildForSearch(cousin);
            }
            return cousin;
        }

        public TreeNode<T> GetParent(TreeNode<T> child)
        {
            if (child.HasParent)
            {
                return child.Parent;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return Data != null ? Data.ToString() : "[data null]";
        }


        #region searching        
        private ICollection<TreeNode<T>> ElementsIndex { get; set; }

        private void RegisterChildForSearch(TreeNode<T> node)
        {
            ElementsIndex.Add(node);
            if (Parent != null)
                Parent.RegisterChildForSearch(node);
        }

        private void RemoveChildFromSearch(TreeNode<T> node)
        {
            ElementsIndex.Remove(node);
            if (Parent != null)
                Parent.RemoveChildFromSearch(node);
        }

        public TreeNode<T> FindTreeNode(Func<TreeNode<T>, bool> predicate)
        {
            return this.ElementsIndex.FirstOrDefault(predicate);
        }

        #endregion


        #region iterating        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            yield return this;
            if (this.HasChildren)
            {
                foreach (var directChild in this.Children)
                {
                    foreach (var anyChild in directChild)
                        yield return anyChild;
                }
            }
        }

        public TreeNode<T> TraverseUpUntil(TreeNode<T> startingNode, int upperLimit)
        {
            TreeNode<T> returnNode = startingNode;
            if ((upperLimit <= (int)DbObjectLevel.Root) || (upperLimit > startingNode.TreeNodeLevel))
            {
                throw new Exception(string.Concat("Parameter upperLimit supplied to method TraverseUpUntil(): [", upperLimit
                , "] does not fit within the correct value-range, which is: ["
                , (int)DbObjectLevel.Root, "] - [", startingNode.TreeNodeLevel, "]"));
            }
            else
            {
                while ((returnNode.TreeNodeLevel != upperLimit) && (returnNode.TreeNodeLevel > (int)DbObjectLevel.Root))
                {
                    returnNode = returnNode.Parent;
                }
                if (returnNode.TreeNodeLevel <= 0)
                {
                    throw new Exception(string.Concat("Method TraverseUpUntil() could not find a TreeNode with a level of: ["
                    , upperLimit, "] traversing up from node: ["
                    , startingNode.TreeNodeLevel, "]"));
                }
            }
            return returnNode;
        }
        #endregion


        #region dmlOperations 
        public void EmptySubtreeText(TreeNode<DbObject> startingNode)
        {
            foreach (TreeNode<DbObject> childNode in startingNode.Children)
            {
                foreach (TreeNode<DbObject> node in childNode)
                {
                    if ((node != null) && typeof(T).Equals(typeof(DbObject)))
                    {
                        DbObject dbObject = (DbObject)Convert.ChangeType(node.Data, typeof(DbObject));
                        if (dbObject != null)
                        {
                            if (dbObject.ObjectText != null)
                            {
                                if (dbObject.ObjectText.Length > 0) // we do not want to set an empty text of a node which is already empty
                                                                    // because then we would unnecessarily trigger events OnDbObjectModified
                                                                    // (which would then cause multiple triggers of SetTreeNodeText)
                                {
                                    dbObject.SetDbObjectText(node, string.Empty);
                                }
                            }
                            else
                            {
                                /*
                                instead of emptying an already empty node text we clear its Gui object
                                (needed to cleanup remaining child Gui elements in case a parent ComboBox
                                is re - selected with SelectedIndex == 0)
                                */
                                if (dbObject.Gui != null)
                                {
                                    dbObject.Gui.ClearGui();
                                }
                            }
                        }
                    }
                }
            }
        }

        public void SetTreeNodeText(TreeNode<DbObject> node, string newText)
        {
            if (node != null)
            {
                node.EmptySubtreeText(node);
                DbObject dbObject = TreeNode<DbObject>.ConvertToDbObject(node);
                if (dbObject != null)
                {
                    dbObject.SetDbObjectText(node, newText);
                }
            }
        }

        public void SetTextOfDirectChildren(TreeNode<T> startingNode, string newText)
        {
            foreach (TreeNode<T> childNode in startingNode.Children)
            {
                foreach (TreeNode<T> node in childNode)
                {
                    if ((node != null) && typeof(T).Equals(typeof(DbObject)) && node.TreeNodeLevel == startingNode.TreeNodeLevel + 1) // set only direct Children of startingNode
                    {
                        DbObject dbObject = (DbObject)Convert.ChangeType(node.Data, typeof(DbObject));
                        if (dbObject != null)
                        {
                            dbObject.SetDbObjectText(ConvertToTreeNodeDbObject(node), newText);
                        }
                    }
                }
            }
        }

        public void SetCloneable(bool cloneable )
        {
            this.CloneableFromSrc = cloneable;
            if (this.HasChildren)
            {
                foreach (TreeNode<T> childNode in this.Children)
                {
                    foreach (TreeNode<T> node in childNode)
                    {
                        node.CloneableFromSrc = cloneable;
                    }
                }
            }
        }

        #endregion

        #region eventHandling
        public void AddEventHandlerNodeCreated(TreeNode<T> t)
        {
            t.eventNodeCreated += new HandlerNodeCreated(OnChildNodeCreated);
            if ((t != null) && typeof(T).Equals(typeof(DbObject)))
            {
                DbObject dbObject = (DbObject)Convert.ChangeType(t.Data, typeof(DbObject));
                if (dbObject != null)
                {
                    var nodeCreated = eventNodeCreated as HandlerNodeCreated;
                    if (nodeCreated != null)
                    {
                        nodeCreated(t, new EventArgsNodeCreated(dbObject, t.TreeNodeLevel)); //this line triggers the execution of method(s) specified on t.eventNodeAdded in AddEventHandler()
                    }
                }
            }
            t.eventNodeCreated -= new HandlerNodeCreated(OnChildNodeCreated);
        }

        protected virtual void OnChildNodeCreated(object sender, EventArgsNodeCreated e)
        {
            //Console.WriteLine("Inside OnChildNodeCreated() for ObjectName " + e.DbObject.ObjectName + ": ObjectLevel: " + e.DbObject.ObjectLevel + ", TreeNodeLevel: " + e.TreeNodeLevel);
            if (e.DbObject.ObjectLevel != e.TreeNodeLevel)
            {
                throw new Exception(
                    "You are trying to assign a dbObject [" + e.DbObject.ObjectName
                    + "] of type: [" + DbObject.GetObjectLevelByIndex(e.DbObject.ObjectLevel)
                    + "] to a TreeNode of type: [" + DbObject.GetObjectLevelByIndex(e.TreeNodeLevel - 1)
                    + "] correct parent-assignment of this dbObject type should be to: [" + DbObject.GetObjectLevelByIndex(e.DbObject.ObjectLevel - 1) + "]");
            }
            //TreeNode<DbObject> t = (TreeNode<DbObject>)Convert.ChangeType(sender, typeof(TreeNode<DbObject>));
            TreeNode<DbObject> t = ConvertToTreeNodeDbObject(sender);

            if (t != null && t.HasParent)
            {
                DbObject dbParent = t.Parent.Data;
                if ((dbParent != null) && (dbParent.ObjectLevel + 1 != e.DbObject.ObjectLevel))
                {
                    throw new Exception(
                    "You are trying to assign a dbObject [" + e.DbObject.ObjectName
                    + "] of type: [" + DbObject.GetObjectLevelByIndex(e.DbObject.ObjectLevel)
                    + "] to a Parent of type: [" + DbObject.GetObjectLevelByIndex(dbParent.ObjectLevel)
                    + "] correct parent-assignment of this dbObject type should be to: [" + DbObject.GetObjectLevelByIndex(e.DbObject.ObjectLevel - 1) + "]");
                }
            }
        }

        protected virtual void OnRootNodeCreated(object sender, EventArgsNodeCreated e)
        {
            //Console.WriteLine("Inside OnRootNodeCreated() for ObjectName " + e.DbObject.ObjectName + ": ObjectLevel: " + e.DbObject.ObjectLevel + ", TreeNodeLevel: " + e.TreeNodeLevel);
            if (e.DbObject.ObjectLevel != e.TreeNodeLevel)
            {
                throw new Exception(
                    "You are trying to assign a dbObject [" + e.DbObject.ObjectName
                    + "] of type: [" + DbObject.GetObjectLevelByIndex(e.DbObject.ObjectLevel)
                    + "] to a TreeNode of type: [" + DbObject.GetObjectLevelByIndex(e.TreeNodeLevel - 1)
                    + "] correct parent-assignment of this dbObject type should be to: [" + DbObject.GetObjectLevelByIndex(e.DbObject.ObjectLevel - 1) + "]");
            }
        }

        protected virtual void OnEnabledStateChanged(object sender, EventArgsNodeChanged e)
        {
            //Console.WriteLine(string.Concat("OnEnabledStateChanged() Executing for TreeNode: ", e.TreeNode.Data.ObjectName, " with new EnabledState: ", e.NewEnabledState.ToString()));
            DbObject dbObject = (DbObject)Convert.ChangeType(e.TreeNode.Data, typeof(DbObject));
            if (dbObject != null)
            {
                if (e.NewEnabledState)
                {
                    if (dbObject.Gui.GetGuiText().Length > 0) // re-eanable only those Gui Elements that aren't empty
                    {
                        dbObject.Gui.SetEnabled(e.NewEnabledState);
                    }
                }
                else
                {
                    dbObject.Gui.SetEnabled(e.NewEnabledState);
                }
            }
        }

        #endregion eventHandling

        #region converting
        public static TreeNode<DbObject> ConvertToTreeNodeDbObject(TreeNode<T> t)
        {
            TreeNode<DbObject> o = t as TreeNode<DbObject>;
            return o;
        }

        public static TreeNode<DbObject> ConvertToTreeNodeDbObject(object sender)
        {
            TreeNode<DbObject> o = sender as TreeNode<DbObject>;
            return o;
        }

        public static DbObject ConvertToDbObject(TreeNode<T> t)
        {
            DbObject dbObject = (DbObject)Convert.ChangeType(t.Data, typeof(DbObject));
            if (dbObject != null)
            {
                return dbObject;
            }
            else
            {
                throw new Exception("Could not convert object of type: " + typeof(T) + " containing Data: " + t.Data.ToString() + " to: DbObject");
            }
        }

        public static DbObject ConvertToDbObject(TreeNode<DbObject> t)
        {
            DbObject dbObject = (DbObject)Convert.ChangeType(t.Data, typeof(DbObject));
            if (dbObject != null)
            {
                return dbObject;
            }
            else
            {
                throw new Exception("Could not convert object of type: " + typeof(DbObject) + " containing Data: " + t.Data.ToString() + " to: DbObject");
            }
        }
        #endregion converting

        #region printing
        public static void PrintNodeTree(TreeNode<DbObject> startingNode)
        {
            foreach (TreeNode<DbObject> node in startingNode)
            {
                string indent = CreateIndent(node.TreeNodeLevel);
                Console.WriteLine(indent + string.Concat("[", node.Data.ObjectName, "] - [", (node.Data.ObjectText ?? "null") + (node.CloneableFromSrc ? "Cloneable" : ""), "]"));
            }
        }

        private static String CreateIndent(int depth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                sb.Append("|_");
            }
            return sb.ToString();
        }
        #endregion
    }
}

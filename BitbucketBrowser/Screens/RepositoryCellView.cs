
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using BitbucketBrowser.Utils;

namespace BitbucketBrowser
{
    public partial class RepositoryCellView : UITableViewCell
    {
        private static UIImage Commit;
        private static UIImage Heart;
        private static UIImage Fork;

        static RepositoryCellView()
        {
            Commit = new UIImage(Images.ScmType.CGImage, 1.3f, UIImageOrientation.Up);
            Heart = new UIImage(Images.Heart.CGImage, 1.3f, UIImageOrientation.Up);
            Fork = new UIImage(Images.Fork.CGImage, 1.3f, UIImageOrientation.Up);
        }

        public static RepositoryCellView Create()
        {
            var cell = new RepositoryCellView();
            var views = NSBundle.MainBundle.LoadNib("RepositoryCellView", cell, null);
            cell = Runtime.GetNSObject( views.ValueAt(0) ) as RepositoryCellView;

            cell.Image1.Image = Commit;
            cell.Image2.Image = Heart;
            cell.Image3.Image = Fork;

            cell.BackgroundView = new UIImageView(Images.CellGradient);

            //Create the icons
            return cell;
        }


        public RepositoryCellView()
            : base()
        {
        }

        public RepositoryCellView(IntPtr handle)
            : base(handle)
        {
        }

        public void Bind(string name, string name1, string name2, string name3, string description)
        {
            Caption.Text = name;
            Label1.Text = name1;
            Label2.Text = name2;
            Label3.Text = name3;
            Description.Text = description ?? "";

            if (string.IsNullOrEmpty(Description.Text))
            {
                Caption.Frame = new RectangleF(Caption.Frame.X, this.Frame.Height / 2 - Caption.Font.LineHeight / 2 - 2, Caption.Frame.Width, Caption.Frame.Height);
            }
            else
            {
                var height = Description.Text.MonoStringHeight(Description.Font, Description.Frame.Width);
                if (height < Description.Font.LineHeight + 3)
                {
                    Caption.Frame = new RectangleF(Caption.Frame.X, Caption.Frame.Y + 8f, Caption.Frame.Width, Caption.Frame.Height);
                }
            }


        }

    }
}

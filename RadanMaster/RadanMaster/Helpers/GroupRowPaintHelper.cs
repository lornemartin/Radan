using DevExpress.Skins;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RadanMaster
{
    public class GroupRowPaintHelper
    {
        public static void CustomDrawSubjectColumnGroupRow(RowObjectCustomDrawEventArgs e, GridView view, DevExpress.LookAndFeel.UserLookAndFeel lookAndFeel, ImageList imgList)
        {
            var info = e.Info as GridGroupRowInfo;
            DrawGradientBackground(e, info);
            DrawExpandButton(e, info, view, lookAndFeel);
            var textPos = DrawGroupRowCustomImage(e, info, view, imgList);
            DrawFormattedString(info, textPos);
        }
        private static void DrawGradientBackground(RowObjectCustomDrawEventArgs e, GridGroupRowInfo info)
        {
            var linGrBrush = new LinearGradientBrush(info.DataBounds,
                                                 Color.FromArgb(0xFF, 0xFF, 0x99),
                                                 Color.FromArgb(0x00, 0xCC, 0x00),
                                                 45);
            e.Cache.FillRectangle(linGrBrush, info.DataBounds);
        }
        private static void DrawExpandButton(RowObjectCustomDrawEventArgs e, GridGroupRowInfo info, GridView view, DevExpress.LookAndFeel.UserLookAndFeel lookAndFeel)
        {
            Image img = GetExpandButtonImage(e, view, lookAndFeel);
            if (img == null) return;
            info.Cache.Paint.DrawImage(e.Cache.Graphics, img, info.ButtonBounds);
        }
        private static Image GetExpandButtonImage(RowObjectCustomDrawEventArgs e, GridView view, DevExpress.LookAndFeel.UserLookAndFeel lookAndFeel)
        {
            var currentSkin = GridSkins.GetSkin(lookAndFeel);
            var plusMinusButton = currentSkin[GridSkins.SkinPlusMinus];
            var images = plusMinusButton.Image.GetImages();
            var rowExpanded = view.GetRowExpanded(e.RowHandle);
            var imgIndex = rowExpanded ? 1 : 0;
            var img = images.Images[imgIndex];
            return img;
        }
        private static void DrawFormattedString(GridGroupRowInfo info, Point textPos)
        {
            var text = GetCustomDisplayText(info.GroupValueText);
            var textFont = new Font(info.Appearance.Font, FontStyle.Italic | FontStyle.Bold);
            var textBrush = new SolidBrush(Color.FromArgb(0x00, 0x66, 0x00));
            info.Cache.Paint.DrawString(info.Cache, text, textFont, textBrush, textPos);
        }
        private static string GetCustomDisplayText(string groupValueText)
        {
            return string.Format("Group row custom caption: {0}", groupValueText);
        }
        private static Point DrawGroupRowCustomImage(RowObjectCustomDrawEventArgs e, GridGroupRowInfo info, GridView view, ImageList imgList)
        {
            var imgIndex = view.GetDataSourceRowIndex(e.RowHandle);
            Image img;
            img = GetGroupRowCustomImage(imgList, imgIndex);
            var imgPos = CalcImgPosition(e, info);
            if (img == null) return imgPos;
            info.Cache.Paint.DrawImage(e.Cache.Graphics, img, imgPos);
            Point imageRightBottomCorner = new Point(imgPos.X + img.Width, imgPos.Y);
            return imageRightBottomCorner;
        }
        private static Image GetGroupRowCustomImage(ImageList imgList, int imgIndex)
        {
            Image img;
            try
            {
                img = imgList.Images[Math.Abs(imgIndex)];
            }
            catch
            {
                var defaultImg = imgList.Images[0];
                img = defaultImg;
            }
            return img;
        }
        private static Point CalcImgPosition(RowObjectCustomDrawEventArgs e, GridGroupRowInfo info)
        {
            return new Point(info.ButtonBounds.Right, info.ButtonBounds.Y);
        }
    }
}

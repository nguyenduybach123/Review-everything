using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Review_Project.Core;
using Review_Project.MVVM.View.UserControlView;
using System.Windows.Controls;

namespace Review_Project.MVVM.ViewModel
{
    public class PostContentEditorViewModel : BaseViewModel
    {

        public ICommand SubmitUnderlineSelectionCommand { get; set; }
        public ICommand SubmitItalicSelectionCommand { get; set; }
        public ICommand SubmitBoldSelectionCommand { get; set; }
        public ICommand SubmitAlignLeftSelectionCommand { get; set; }
        public ICommand SubmitAlignRightSelectionCommand { get; set; }
        public ICommand SubmitAlignCenterSelectionCommand { get; set; }
        public ICommand SubmitUnselectAlignCommand { get; set; }
        public ICommand SelectedChangedFontSizeCommand { get; set; }
        public ICommand TextChangedContentCommand { get; set; }
        public ICommand SubmitSeeButtonCommand { get; set; }
        public ICommand SubmitMediaButtonCommand { get; set; }
        public ICommand SubmitCloseEditorButtonCommand { get; set; }
        public PostContentEditorViewModel()
        {

            SubmitUnderlineSelectionCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);

                if (!postEditorUC.boxUnderline.IsSelected)
                {
                    selectedTextRange.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
                }
                else
                {
                    selectedTextRange.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                }
            });

            SubmitItalicSelectionCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);

                if (!postEditorUC.boxItalic.IsSelected)
                {
                    selectedTextRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
                }
                else
                {
                    selectedTextRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                }
            });

            SubmitBoldSelectionCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);

                if (!postEditorUC.boxBold.IsSelected)
                {
                    selectedTextRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
                }
                else
                {
                    selectedTextRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                }
            });


            SubmitAlignLeftSelectionCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);
                Paragraph paragraph = selectedTextRange.Start.Paragraph;
                paragraph.TextAlignment = TextAlignment.Left;
            });

            SubmitAlignRightSelectionCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);
                Paragraph paragraph = selectedTextRange.Start.Paragraph;
                paragraph.TextAlignment = TextAlignment.Right;
            });

            SubmitAlignCenterSelectionCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);
                Paragraph paragraph = selectedTextRange.Start.Paragraph;
                paragraph.TextAlignment = TextAlignment.Center;
            });

            SubmitUnselectAlignCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                if(!postEditorUC.boxAlignCenter.IsSelected && !postEditorUC.boxAlignRight.IsSelected)
                    postEditorUC.boxAlignLeft.IsSelected = true;
            });

            SelectedChangedFontSizeCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {

                if (postEditorUC.cbxFontSize.SelectedValue != null)
                {
                    ComboBoxItem cbxItemSelected = postEditorUC.cbxFontSize.SelectedValue as ComboBoxItem;
                    string fontSizeString = cbxItemSelected.Content.ToString();

                    if (int.TryParse(fontSizeString, out int fontSize))
                    {
                        TextRange selectedTextRange = new TextRange(postEditorUC.postContent.Selection.Start, postEditorUC.postContent.Selection.End);
                        selectedTextRange.ApplyPropertyValue(TextElement.FontSizeProperty, (double)fontSize);
                    }
                }
            });

            TextChangedContentCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                Paragraph lastParagraph = postEditorUC.postContent.Document.Blocks.LastBlock as Paragraph;
                if (lastParagraph != null)
                {
                    Run lastRun = lastParagraph.Inlines.LastInline as Run;
                    if (lastRun != null)
                    {
                        if (postEditorUC.boxBold.IsSelected)
                        {
                            lastRun.FontWeight = FontWeights.Bold;
                        }
                        if (postEditorUC.boxItalic.IsSelected)
                        {
                            lastRun.FontStyle = FontStyles.Italic;
                        }
                        if (postEditorUC.boxUnderline.IsSelected)
                        {
                            lastRun.TextDecorations = TextDecorations.Underline;
                        }

                    }
                }
            });


            SubmitMediaButtonCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                OpenFileDialog openfileDialog = new OpenFileDialog();
                openfileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg;*.png| Video files (*.mp4)|*.mp4";
                openfileDialog.FilterIndex = 1;
                openfileDialog.Multiselect = true;
                openfileDialog.Title = "Chọn Ảnh | Video";

                if (openfileDialog.ShowDialog() == true)
                {
                    string fileExtension = Path.GetExtension(openfileDialog.FileName);

                    if (fileExtension == ".jpg" || fileExtension == ".png")
                    {
                        Image imageUI = new Image();
                        imageUI.Source = new BitmapImage(new Uri(openfileDialog.FileName));
                        InlineUIContainer inlineUIContainer = new InlineUIContainer(imageUI);
                        postEditorUC.postContent.Selection.Start.Paragraph.Inlines.Add(inlineUIContainer);
                    }
                }
            });


            SubmitSeeButtonCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
            // Assume richTextBox is the RichTextBox control
                foreach (Block block in postEditorUC.postContent.Document.Blocks)
                {
                    if (block is Paragraph paragraph)
                    {
                        foreach (Inline inline in paragraph.Inlines)
                        {
                            if (inline is Run run)
                            {
                                if (run.FontWeight == FontWeights.Bold)
                                {
                                    // Nội dung in đậm
                                    string boldText = run.Text;
                                    // Xử lý nội dung in đậm ở đây
                                }
                                else
                                {
                                    // Nội dung bình thường
                                    string normalText = run.Text;
                                    // Xử lý nội dung bình thường ở đây
                                }
                            }
                            if (inline is InlineUIContainer uiContainer && uiContainer.Child is Image)
                            {
                                // Đây là một Run chứa một đối tượng Image
                                Console.WriteLine("Là Hình ảnh");
                                // Thực hiện xử lý cho đối tượng Image tại đây
                            }
                        }
                    }
                }
            });

            SubmitCloseEditorButtonCommand = new RelayCommand<PostContentEditorUC>((postEditorUC) => { return true; }, (postEditorUC) => {
                MessageBoxResult result = MessageBox.Show("Bạn có muốn hủy bài viết?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    postEditorUC.Container.Children.Remove(postEditorUC);
                }
            });
        }
    }
}

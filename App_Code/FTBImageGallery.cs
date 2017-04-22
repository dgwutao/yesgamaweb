using System;
using FreeTextBoxControls;
using System.Web;
using System.IO;

namespace CustomFTB
{
    public class FTBImageGallery : ImageGallery
    {
        public FTBImageGallery()
        {
        }

        public override void RaisePostBackEvent(string eventArgument)
        {
            char[] chArray1 = new char[] { ':' };
            string[] textArray1 = eventArgument.Split(chArray1);
            if (textArray1[0] != null && textArray1[0] == "UploadImage")
            {
                this.EnsureChildControls();

                if (!this.AllowImageUpload)
                {
                    this.returnMessage = "不允许上传";
                    return;
                }
                if (this.inputFile == null)
                {
                    this.returnMessage = "Error: InputFile control not yet created!";
                    return;
                }
                if ((this.inputFile.PostedFile == null) || (this.inputFile.PostedFile.FileName == null))
                {
                    throw new Exception("请选择需要上传的图片");
                }
                if (!(IsAcceptedFileTypes(this.inputFile.PostedFile.FileName)))
                {
                    this.returnMessage = "不允许上传该类型的图片";
                    return;
                }
                //string filename = DateTime.Now.ToString("yyyMMddhhmmss"); 
                string newFileName = Guid.NewGuid() + Path.GetExtension(this.inputFile.PostedFile.FileName);
                this.inputFile.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(this.CurrentImagesFolder) + @"\" + newFileName);
                this.returnMessage = "图片上传成功";
                HttpContext.Current.Cache.Remove("FTB-Images-" + this.CurrentImagesFolder);

                return;
                /*
                if (this.inputFile.PostedFile != null && this.inputFile.PostedFile.FileName != null && !(IsAcceptedFileTypes(this.inputFile.PostedFile.FileName)))
                {
                this.returnMessage = "不允许上传该类型的文件";
                return;
                }
                */

            }
            base.RaisePostBackEvent(eventArgument);
        }

        private bool IsAcceptedFileTypes(string fileName)
        {
            for (int i = 0; i < this.AcceptedFileTypes.Length; i++)
            {
                if (fileName.ToLower().EndsWith("." + this.AcceptedFileTypes[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
 

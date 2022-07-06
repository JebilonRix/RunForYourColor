using UnityEngine.UI;

namespace RedPanda.UI
{
    [System.Serializable]
    public class ImageList
    {
        public ImageList(Image nameImage, Image flagImage)
        {
            this.nameImage = nameImage;
            this.flagImage = flagImage;
        }

        public Image nameImage;
        public Image flagImage;
    }
}
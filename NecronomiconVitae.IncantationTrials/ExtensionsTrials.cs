// ------------------------------------
// Necronomicon Vitae
// ------------------------------------

using NecronomiconVitae.CorpusMaleficarum;
using NecronomiconVitae.CorpusMaleficarum.Models;

namespace NecronomiconVitae.IncantationTrials;

[TestClass]
public class ExtensionsTrials
{
    private readonly ImageBuilder _imageBuilder;
    private List<Image> _images;

    public ExtensionsTrials()
    {
        _imageBuilder = new();

        var image = _imageBuilder.Build();
        var image2 = _imageBuilder.Build();
        var image3 = _imageBuilder.Build();

        _images = [image, image2, image3];
    }

    [TestMethod]
    public void AddDefaultTags_AddsImageTag()
    {
        _images.ForEach(x => { Assert.IsNull(x.Tags); });

        // Act
        _images.AddDefaultTags();

        // Assert
        _images.ForEach(x =>
        {
            Assert.AreEqual(expected: 1, x.Tags!.Count);
            Assert.AreEqual(expected: ImageTag.Image.ToString(), x.Tags[0]);
        });
    }

    [TestMethod]
    public void AssignIds_AssignsUniqueIdsToEachImage()
    {
        _images.ForEach(x => { Assert.IsNull(x.Id); });

        // Act
        _images.AssignIds();

        // Assert
        _images.ForEach(x => { Assert.IsNotNull(x.Id); });
    }

    [TestMethod]
    public void GetImagesByTags_ReturnsDictionaryOfImagesIndexedByTagName()
    {
        // Arrange
        var defaultTag = ImageTag.Image.ToString();
        var tag1 = "Tag1";
        var tag2 = "Tag2";

        _images.AddDefaultTags();

        _images[0].Tags!.Add(tag1);
        _images[1].Tags!.Add(tag1);
        _images[2].Tags!.Add(tag2);

        // Act
        var imagesByTag = _images.GetImagesByTags();

        // Assert
        Assert.AreEqual(expected: 3, imagesByTag.Count);

        Assert.IsTrue(imagesByTag.ContainsKey(defaultTag));
        Assert.AreEqual(expected: 3, imagesByTag[defaultTag].Count());

        Assert.IsTrue(imagesByTag.ContainsKey(tag1));
        Assert.AreEqual(expected: 2, imagesByTag[tag1].Count());

        Assert.IsTrue(imagesByTag.ContainsKey(tag2));
        Assert.AreEqual(expected: 1, imagesByTag[tag2].Count());
    }
}
namespace Fileforge.Domain.Entities;

public class DocumentChunk
{
    public Guid Id { get; private set; }
    public Guid DocumentId { get; private set; }
    public int Index { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public int TokenCount { get; private set; }
    public ReadOnlyMemory<float> Embedding { get; private set; }

    // Needed by EF.
    public DocumentChunk() { }

    public DocumentChunk(Guid documentId, int index, string content, int tokenCount, ReadOnlyMemory<float> embedding)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new Exceptions.DomainException("Chunk content is required.");

        Id = Guid.NewGuid();
        DocumentId = documentId;
        Index = index;
        Content = content;
        TokenCount = tokenCount;
        Embedding = embedding;
    }
}

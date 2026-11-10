# .NET Core RAG – Document Question Answering

A sample application demonstrating how to implement **Retrieval-Augmented Generation (RAG)** using ASP.NET Core and AI.

This project allows users to upload documents and ask questions related to their content. Instead of relying entirely on the AI model's pre-trained knowledge, the application retrieves relevant information from uploaded documents and uses it to generate context-aware answers.

## 🚀 Project Overview

The application demonstrates a practical implementation of RAG (Retrieval-Augmented Generation).

**Key capabilities:**
- Upload documents through an API endpoint.
- Extract and process document content.
- Convert document content into vector embeddings.
- Store embeddings for semantic search.
- Ask questions based on uploaded documents.
- Retrieve relevant document content.
- Generate AI-powered answers using the retrieved context.

## 🔄 How It Works

The application follows two major workflows.

### 1. Document Upload and Processing

When a user uploads a document:

1. The document is received through the Upload Document API.
2. Text content is extracted from the document.
3. The extracted content is divided into smaller chunks.
4. Each chunk is converted into vector embeddings.
5. The embeddings and associated content are stored for future retrieval.

### 2. Ask Questions About Documents

When a user submits a question:

1. The question is received through the Question API.
2. The question is converted into a vector embedding.
3. The application performs semantic similarity search against stored document embeddings.
4. Relevant document chunks are retrieved.
5. Retrieved content is passed to the AI model as context.
6. The AI model generates an answer based on the retrieved information.

## 🏗️ RAG Architecture

```text
             DOCUMENT UPLOAD
                    |
                    v
             Upload Document API
                    |
                    v
             Extract Document Text
                    |
                    v
                Text Chunking
                    |
                    v
             Generate Embeddings
                    |
                    v
             Store Vector Data
                    |
                    |
             USER ASKS QUESTION
                    |
                    v
               Question API
                    |
                    v
            Generate Question Embedding
                    |
                    v
             Semantic Similarity Search
                    |
                    v
             Retrieve Relevant Chunks
                    |
                    v
             Build Context for AI
                    |
                    v
              AI Language Model
                    |
                    v
              Generate Answer
```

## 🛠️ Technologies Used

- **Backend:** ASP.NET Core Web API
- **Language:** C#
- **AI Integration:** Large Language Models (LLMs)
- **RAG Pattern:** Retrieval-Augmented Generation
- **Embeddings:** Vector Embeddings
- **Vector Search:** Based on the configured vector storage implementation

## 📡 API Endpoints

### 1. Upload Document

Upload a document to make its content available for AI-powered question answering.

```http
POST /api/document/upload
```

**Purpose:**
- Upload a document.
- Extract document content.
- Generate embeddings.
- Store document chunks for retrieval.

### 2. Ask a Question

Ask questions related to the uploaded document.

```http
POST /api/document/ask
```

**Example request:**

```json
{
  "question": "What are the main topics discussed in this document?"
}
```

**Example response:**

```json
{
  "answer": "The document discusses..."
}
```

*Note: The endpoint routes and JSON properties above are illustrative. Adjust them to match the actual API implementation.*

## ⚙️ Getting Started

### Prerequisites

- .NET SDK compatible with the project.
- Visual Studio or Visual Studio Code.
- AI model API credentials, if using an external AI provider.
- Vector storage configured by the application.

### Installation

1. Clone the repository.

```bash
git clone <your-repository-url>
```

2. Navigate to the project directory.

```bash
cd <your-project-folder>
```

3. Configure the required AI provider credentials and vector storage settings.

4. Restore dependencies.

```bash
dotnet restore
```

5. Run the application.

```bash
dotnet run
```

6. Open the Swagger URL configured for the application to explore and test the APIs.

## 💡 What You Will Learn

By exploring this project, you will understand:

- What Retrieval-Augmented Generation (RAG) is.
- How document ingestion works in an AI application.
- How text chunking improves document retrieval.
- What embeddings are and why they are important.
- How semantic similarity search works.
- How to provide relevant context to an LLM.
- How to build document-based AI question-answering applications using .NET.

## 🎯 Use Cases

The same approach can be extended to build:

- Document-based AI assistants.
- Enterprise knowledge management systems.
- Legal document analysis applications.
- Customer support knowledge assistants.
- Technical documentation assistants.
- Internal company knowledge-base chatbots.

## 📌 Purpose of This Repository

This is a learning and demonstration project created to explore practical AI integration using the .NET ecosystem.

The goal is to understand how modern AI concepts such as RAG, embeddings, semantic search, and LLM integration can be implemented in real-world ASP.NET Core applications.

Contributions and suggestions are welcome!
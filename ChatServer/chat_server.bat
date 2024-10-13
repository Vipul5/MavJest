#!/bin/bash

# Check if ollama is installed
if ! command -v ollama &> /dev/null
then
    echo "ollama command could not be found. Please install it first."
    exit 1
fi

# Pull the phi3:mini model
echo "Pulling phi3:mini model..."
ollama pull phi3:mini

# Run the phi3:mini model
echo "Running phi3:mini model..."
ollama run phi3:mini

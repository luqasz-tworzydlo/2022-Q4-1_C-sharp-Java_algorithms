class CHuffmanLeaf extends BHuffmanTree {
    // wartość (symbol), która jest reprezentowana przez dany liść
    // [ czyli jaki symbol jest dla jakiej częstotliwości ]
    public final char ValueSymbol;

    public CHuffmanLeaf(int S_Frequency, char Value_S) {
        super(S_Frequency);
        ValueSymbol = Value_S;
    }
}
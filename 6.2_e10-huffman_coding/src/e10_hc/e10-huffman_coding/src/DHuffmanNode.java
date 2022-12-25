class DHuffmanNode extends BHuffmanTree {
    // nasze 'poddrzewa' [ lewa krawędź = 0; prawa krawędź = 1 ]
    public final BHuffmanTree LeftEdge, RightEdge;

    public DHuffmanNode(BHuffmanTree L_left, BHuffmanTree R_right) {
        super(L_left.FrequencyOfTheSymbol + R_right.FrequencyOfTheSymbol);
        LeftEdge = L_left;
        RightEdge = R_right;
    }
}
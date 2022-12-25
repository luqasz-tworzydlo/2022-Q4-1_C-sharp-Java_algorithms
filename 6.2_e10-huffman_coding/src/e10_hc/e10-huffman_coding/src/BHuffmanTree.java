abstract class BHuffmanTree implements Comparable<BHuffmanTree> {
    // wartość liczbowa, frekwencja naszego drzewa
    public final int FrequencyOfTheSymbol;
    public BHuffmanTree(int S_Frequency) { FrequencyOfTheSymbol = S_Frequency; }

    // compares on the frequency
    public int compareTo(BHuffmanTree tree) {
        return FrequencyOfTheSymbol - tree.FrequencyOfTheSymbol;
    }
}
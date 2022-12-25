import java.util.PriorityQueue;

public class AMain {
    public static void main(String[] args)
    {
        // sposób notacji nr 1
        // nasze symbole w Drzewie Huffmana
        // String HuffmanSymbols = "caefdb"; // [1-3]
        // char[] OurSymbols = HuffmanSymbols.toCharArray(); // [2-3]
        // wartości liczbowe, czyli częstotliwość symboli,
        // które zostały powyżej wypisane [ poniższe wartości
        // zostały posegregoweane od najmniejszej do największej,
        // jak i również analogicznie ich symbole powyżej ]
        // int[] SymbolsFrequency = {17,27,47,57,77,87}; // [3-3]

        // sposób notacji nr 2
        // poniższe wartości [symbole oraz ich częstotliwości]
        // nie zostały posegregowane, lecz podane pokolei [*]
        String HuffmanSymbols = "abcdef"; // [1-3]
        char[] OurSymbols = HuffmanSymbols.toCharArray(); // [2-3]
        int[] SymbolsFrequency = {27,87,17,77,47,57}; // [3-3]

        // stworzenie, zbudowanie naszego Drzewa Huffmana
        BHuffmanTree OurTree = BuildHuffmanTree(SymbolsFrequency,OurSymbols);

        // wyświetlenie naszych wyników końcowych
        System.out.println("Symbol\tFrequency\tHuffmanCode");
        PrintHuffmanCodes(OurTree, new StringBuffer());
    }
    // nasze Drzewo Huffmana budujemy poprzez wprowadzaenie tablicy z częstotliwościami,
    // gdzie każda z nich jest indeksowana poprzez konkretny kod znaku [***]
    public static BHuffmanTree BuildHuffmanTree(int[] SymbolsFrequency, char[] OurSymbols) {
        PriorityQueue<BHuffmanTree> SymbolsTrees = new PriorityQueue<BHuffmanTree>();
        // na początku mamy zaledwie tzw. 'las liści',
        // gdzie każda jedna wartość jest przypisana
        // do kolejnego niepustego znaku [***]
        for (int i = 0; i < SymbolsFrequency.length; i++)
            if (SymbolsFrequency[i] > 0)
                SymbolsTrees.offer(new CHuffmanLeaf(SymbolsFrequency[i], OurSymbols[i]));

        assert SymbolsTrees.size() > 0;
        // pętla dla naszych symboli [drzew], która będzie
        // zapętlona tak długo, aż zostanie tylko jeden symbol
        while (SymbolsTrees.size() > 1) {
            // dwa symbole z najmniejszą częstotliwością
            BHuffmanTree a = SymbolsTrees.poll();
            BHuffmanTree b = SymbolsTrees.poll();

            // umieszczenie wartości w 'HuffmanNode'
            // oraz ponowne wstawienie wartości do kolejki
            SymbolsTrees.offer(new DHuffmanNode(a, b));
        }
        return SymbolsTrees.poll();
    }

    public static void PrintHuffmanCodes(BHuffmanTree tree, StringBuffer HuffmanCode_Prefix) {
        assert tree != null;
        if (tree instanceof CHuffmanLeaf) {
            CHuffmanLeaf HuffmanLeaf = (CHuffmanLeaf)tree;

            // wyświetlenie naszych wyników, a więc symbolu, częstotliwości oraz Kodu Huffmana
            // dla danego liścia [symbolu], który jest określony jako 'HuffmanCode_Prefix'
            System.out.println(HuffmanLeaf.ValueSymbol + "\t\t\t" + HuffmanLeaf.FrequencyOfTheSymbol + "\t\t\t" + HuffmanCode_Prefix);

        } else if (tree instanceof DHuffmanNode) {
            DHuffmanNode HuffmanNode = (DHuffmanNode)tree;

            // wartość dla przejścia w lewą stronę
            // lewa krawędź, a więc lewe przejście = 1
            HuffmanCode_Prefix.append('0');
            PrintHuffmanCodes(HuffmanNode.LeftEdge, HuffmanCode_Prefix);
            HuffmanCode_Prefix.deleteCharAt(HuffmanCode_Prefix.length()-1);

            // wartość dla przejścia w prawą stronę
            // prawa krawędź, a więc prawe przejście = 1
            HuffmanCode_Prefix.append('1');
            PrintHuffmanCodes(HuffmanNode.RightEdge, HuffmanCode_Prefix);
            HuffmanCode_Prefix.deleteCharAt(HuffmanCode_Prefix.length()-1);
        }
    }
}

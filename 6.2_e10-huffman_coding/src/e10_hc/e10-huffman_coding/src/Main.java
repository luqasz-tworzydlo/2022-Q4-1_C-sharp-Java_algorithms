import java.util.PriorityQueue;

public class Main {
    public static void main(String[] args)
    {
        // nasze symbole w Drzewie Huffmana
        String HuffmanSymbols = "caefdb";
        char[] OurSymbols = HuffmanSymbols.toCharArray();
        // wartości liczbowe, czyli częstotliwość symboli,
        // które zostały powyżej wypisane [ poniższe wartości
        // zostały posegregoweane od najmniejszej do największej,
        // jak i również analogicznie ich symbole powyżej ]
        int[] SymbolsFrequency = {17,27,47,57,77,87};

        // stworzenie, zbudowanie naszego Drzewa Huffmana
        HuffmanTree OurTree = BuildHuffmanTree(SymbolsFrequency,OurSymbols);

        // wyświetlenie naszych wyników końcowych
        System.out.println("Symbol\tFrequency\tHuffmanCode");
        PrintHuffmanCodes(OurTree, new StringBuffer());
    }
    // nasze Drzewo Huffmana budujemy poprzez wprowadzaenie tablicy z częstotliwościami,
    // gdzie każda z nich jest indeksowana poprzez konkretny kod znaku [***]
    public static HuffmanTree BuildHuffmanTree(int[] SymbolsFrequency, char[] OurSymbols) {
        PriorityQueue<HuffmanTree> SymbolsTrees = new PriorityQueue<HuffmanTree>();
        // na początku mamy zaledwie tzw. 'las liści',
        // gdzie każda jedna wartość jest przypisana
        // do kolejnego niepustego znaku [***]
        for (int i = 0; i < SymbolsFrequency.length; i++)
            if (SymbolsFrequency[i] > 0)
                SymbolsTrees.offer(new HuffmanLeaf(SymbolsFrequency[i], OurSymbols[i]));

        assert SymbolsTrees.size() > 0;
        // pętla dla naszych symboli [drzew], która będzie
        // zapętlona tak długo, aż zostanie tylko jeden symbol
        while (SymbolsTrees.size() > 1) {
            // dwa symbole z najmniejszą częstotliwością
            HuffmanTree a = SymbolsTrees.poll();
            HuffmanTree b = SymbolsTrees.poll();

            // umieszczenie wartości w 'HuffmanNode'
            // oraz ponowne wstawienie wartości do kolejki
            SymbolsTrees.offer(new HuffmanNode(a, b));
        }
        return SymbolsTrees.poll();
    }

    public static void PrintHuffmanCodes(HuffmanTree tree, StringBuffer HuffmanCode_Prefix) {
        assert tree != null;
        if (tree instanceof HuffmanLeaf) {
            HuffmanLeaf HuffmanLeaf = (HuffmanLeaf)tree;

            // wyświetlenie naszych wyników, a więc symbolu, częstotliwości oraz Kodu Huffmana
            // dla danego liścia [symbolu], który jest określony jako 'HuffmanCode_Prefix'
            System.out.println(HuffmanLeaf.ValueSymbol + "\t" + HuffmanLeaf.FrequencyOfTheSymbol + "\t" + HuffmanCode_Prefix);

        } else if (tree instanceof HuffmanNode) {
            HuffmanNode HuffmanNode = (HuffmanNode)tree;

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

abstract class HuffmanTree implements Comparable<HuffmanTree> {
    // wartość liczbowa, frekwencja naszego drzewa
    public final int FrequencyOfTheSymbol;
    public HuffmanTree(int S_Frequency) { FrequencyOfTheSymbol = S_Frequency; }

    // compares on the frequency
    public int compareTo(HuffmanTree tree) {
        return FrequencyOfTheSymbol - tree.FrequencyOfTheSymbol;
    }
}

class HuffmanLeaf extends HuffmanTree {
    // wartość (symbol), która jest reprezentowana przez dany liść
    // [ czyli jaki symbol jest dla jakiej częstotliwości ]
    public final char ValueSymbol;

    public HuffmanLeaf(int S_Frequency, char Value_S) {
        super(S_Frequency);
        ValueSymbol = Value_S;
    }
}

class HuffmanNode extends HuffmanTree {
    // nasze 'poddrzewa' [ lewa krawędź = 0; prawa krawędź = 1 ]
    public final HuffmanTree LeftEdge, RightEdge;

    public HuffmanNode(HuffmanTree L_left, HuffmanTree R_right) {
        super(L_left.FrequencyOfTheSymbol + R_right.FrequencyOfTheSymbol);
        LeftEdge = L_left;
        RightEdge = R_right;
    }
}

import java.io.Console
import java.io.File

fun main(args: Array<String>) {
    val input = "src/main/resources/input.txt"
    val testInput = "src/main/resources/test_input.txt"

    val caloriesSum: MutableList<Int> = mutableListOf();

    val lines: List<String> = File(input).readLines()

    var temp = 0;
    lines.forEach { line ->
        if (line == "") {
            caloriesSum.add(temp);
            temp = 0;
        } else
            temp += line.toInt();
    }
    caloriesSum.add(temp);
    temp = 0;

    caloriesSum.sortDescending();
    //println(caloriesSum)
    println(caloriesSum[0] + caloriesSum[1] + caloriesSum[2]);
}
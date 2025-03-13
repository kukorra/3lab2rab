open System

// Функция для вычисления суммарной длины строк
let totalStringLength strings = 
    strings |> Seq.fold (fun acc str -> acc + String.length str) 0

// Генерация случайных строк
let generateRandomStrings count =
    let rnd = Random()
    let chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
    
    let randomString length =
        Seq.init length (fun _ -> chars.[rnd.Next(chars.Length)]) |> String.Concat

    Seq.init count (fun _ -> randomString (rnd.Next(3, 10)))


// Ввод строк с клавиатуры
let rec readStrings () =
    printf "Введите строку (или пустую строку для завершения): "
    match Console.ReadLine() with
    | "" -> Seq.empty
    | input -> Seq.append (seq { yield input }) (readStrings ()) 

// Основная программа
printf "Выберите способ ввода (1 - случайные строки, 2 - ввод вручную): "
match Console.ReadLine() with
| "1" ->
    let strings = generateRandomStrings 5
    printfn "Сгенерированные строки: %A" (strings |> Seq.toList)
    printfn "Суммарная длина строк: %d" (totalStringLength strings)
| "2" ->
    let strings = readStrings ()
    printfn "Введенные строки: %A" (strings |> Seq.toList)
    printfn "Суммарная длина строк: %d" (totalStringLength strings)
| _ ->
    printfn "Некорректный выбор."

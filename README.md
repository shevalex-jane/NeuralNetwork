# NeuralNetwork
Предварительно были подготовлены 10-ти минутные склеенные файлы, что бы уж точно захватить полезный сигнал и всю его длительность. На 12-ти подготовленных файлах сенсора P3 (10 склеек по 7500 – 1 файл), итого со входом нейронки в 75000 и 12-ти файлах учителей обучается не более 10 минут (core i7). В результате средняя погрешность по всем 12-ти файлам не более 10%. При тесте каждого из файлов дает однозначный ответ относится ли он к S0 (если ответ сети < 0,5) или к S1 (если ответ сети > 0,5) (в большинстве случаев более 0,9 – состояние S1; менее 0,1 – состояние S0). Это говорит о том, что нейросеть работает правильно.

Описание работы программы:
1. Если склеенные файлы для обучения и теста сети имеются, пункты 2 – 6 можно пропустить.
2. Запускать нужно файл NNetwork_FileWriting.exe, находящийся в корневой папке.
3. Далее в верхнем левом углу кнопкой “Directory” выбирается директория, где хранятся файлы с расширением .chk.
4. Далее мышью выбирается набор файлов (будущая склейка) в текстбоксе. В “Writing to the txt file”, в “File name” вводится название будущего склеенного файла. Далее кнопка Write to File создается файл .txt. Представление в double, нормализованный от -1 до +1.
5. Обязательно (!) нужно указать директорию, где будут храниться склеенные файлы: “Choose the directory save files TO:”, кнопка “Directory”.
6. Для удобства поиска нужных файлов так же есть панель “Finding”. Поиск нужных файлов можно производить при помощи набора части имени искомого файла (файлов) в “Finding” после нажатия кнопки “Find on pattern” выведется только те файлы, которые имеют в своем названии введенное начало. (например, при вводе “124636521_C3_0” будут найдены все файлы с таким началом).
7. Кнопка “Open Evaluation Form” переводит на форму работы с нейросетью.
8. В верхней левой части формы необходимо указать путь к файлам для подачи их на вход нейросети как обучающие и/или тестовые. Сейчас это папка “NNetworks_txtFiles” с некоторыми уже склеенными файлами.
9. При обучении мышкой необходимо выбрать те файлы, которые будут участвовать в обучении либо в тесте. Для теста необходимо выбирать только один файл. Если будет выбрано несколько, тест будет произведен с верхним выделенным файлом в списке.
10. Рекомендуется на первое время работы оставлять параметры нейросети как есть. В дальнейшем можно будет их корректировать для лучшей и/или более быстрой сходимости.
11. Кнопка “Convolution_BP” – запуск обучения нейросети по выбранным файлам.
12. Кнопка “Test” – тестирование ранее обученной нейросети выбранным файлом.
13. Кнопка “Save” – сохранение данных обученной нейросети
14. Кнопка “Restore” – загрузка данных ранее сохраненной нейросети.
15. Кнопка “Abort” – принудительный останов обучения нейросети. Может понадобиться, если целевая погрешность (Gaining accuracy) задана очень низкой и на данном этапе видно, что сеть не достигнет этого значения, либо текущая целевая погрешность удовлетворяет.
16. Целевая погрешность (Gaining accuracy) – это средняя итоговая погрешность среди всех выбранных файлов для обучения.
17. В этой программе также доступен просмотр преобразования Гильберта. Кнопка “Hilbert”. Но работает только с двумя выбранными файлами склеенными на 75000 точек. Данная кнопка отношения к нейронной сети не имеет.
18. В корневой папке, в папке NNetworks_txtFiles – уже готовые склеенные файлы на 75000 точек сенсора Р3. В папке cleaned_nn – исходные .chk файлы.

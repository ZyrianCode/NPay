using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// В проектах SDK, таких как этот, некоторые атрибуты сборки, которые ранее определялись
// в этом файле, теперь автоматически добавляются во время сборки и заполняются значениями,
// заданными в свойствах проекта. Подробные сведения о том, какие атрибуты включены
// и как настроить этот процесс, см. на странице: https://aka.ms/assembly-info-properties.


// При установке значения false для параметра ComVisible типы в этой сборке становятся
// невидимыми для компонентов COM. Если вам необходимо получить доступ к типу в этой
// сборке из модели COM, установите значение true для атрибута ComVisible этого типа.

[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов typelib, если этот проект
// будет видимым для COM.

[assembly: Guid("00ba1dde-052c-4d20-b65a-d04e2d1a36f2")]

[assembly: InternalsVisibleTo("NPay.Modules.Notifications.Core")]
[assembly: InternalsVisibleTo("NPay.Modules.Notifications.Application")]
[assembly: InternalsVisibleTo("NPay.Modules.Notifications.Api")]
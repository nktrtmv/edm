## Validation

> > Нужно обновить, т.к. появились conditions

### Validators

* Required (Status/AttributeValue/true)
* Sum (Constant/AttributeValue)
* Regex[]
* =>< (Const/AttributeValue)
* Available (Status/AttributeValue)
* ? Array.Count >=<

AttributeValue[] (&& ||)

Tuple Attribute recursive validation

## Vision:

* Отдельная вкладка с валидаторами (доступна после создания template Attrubutes)
* Валидаторы разных типов (см. [validators](#validators) )
* Кидаем валидатор->туда можно прилинковать(накидать) аттрибуты из этого темплейта. (Фильтрация аттрибутов по типу
  доступных для этого валидатора).
* Добавить целевое значение (targets) из возможных:
    * Const/Value
    * AttributeValue
* Для каждого валидатора есть список статусов документа, на которых этот валидатор проводит проверку.

### Контракты на фронт

* GetListOfValidationRuleTypes()
    * ValidationRuleType
        * Type GetAvailableAttributeTypes(проверить контракты)
        *
* Create rule
    * Link to rule.
      Add target (Const/AttributeId/DocumentStatus(stage))

### Общий контракт:

* Получить типы возможных валидаторов

#### Валидатор:

* получить типы атрибутов (как типы аттрибутов)
* получить типы таргета (const/attributeId/docType) (proto any of)
* Id
* Name
* Description

#### Валидатор инстанс:

### Classes:

* Описание валидатора
* Инстанс валидатора с привязкой атрибутов и возможностью подставить values

## Tests

* Create template
* Add attributes to template
* Add validator
* Add Attributes
* Add Target

### Требования к Values

* NotDefault
* Equals
* Comparable
* Sum? - not generic approach
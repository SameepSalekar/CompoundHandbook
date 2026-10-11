/*
IChemicalEntityClassifier defines the common contract for performing the overall
classification of a ChemicalEntity.

The following ChemicalEntityClassifier class provides an actual implementation of
that interface.

The purpose of this class is to coordinate the different parts of the Classification
system and combine their results into one ChemicalClassificationResult.

The classification process performed by this class can be separated into three main
responsibilities:

(i) Determine the general ChemicalEntityType of the ChemicalEntity.

The Compound Handbook contains different types of chemical entities such as
Molecule, IonicSolid, NetworkCovalentSolid, Metal, and Polymer.

Therefore, the classifier first determines which of these general entity types
the supplied ChemicalEntity belongs to.


(ii) Determine the ChemicalCategory values that apply to the ChemicalEntity.

The classifier does not contain every chemical-classification rule directly
inside this class.

Instead, it receives a collection of objects implementing
IChemicalClassificationRule.

Each classification rule evaluates the ChemicalEntity and returns a
ChemicalClassificationContribution containing the classification information
contributed by that particular rule.

The classifier collects the ChemicalCategory values produced by these different
rules and combines them into one collection.


(iii) Determine which ChemicalOperation values are applicable to the ChemicalEntity.

After the entity and its categories are known, the classifier uses an
IEntityApplicabilityPolicy to determine which operations are chemically
appropriate for that entity.

This keeps the responsibility for deciding operation applicability separate
from the responsibility for coordinating the overall classification process.


After these steps have been completed, ChemicalEntityClassifier creates and returns
a ChemicalClassificationResult containing:

(i)   EntityType
(ii)  Categories
(iii) ApplicableOperations
(iv)  Messages

Therefore, ChemicalEntityClassifier acts as the coordinator of the complete
classification process.

It does not need to contain every individual classification rule or every rule
governing operation applicability itself.

Instead, those responsibilities are delegated to objects implementing
IChemicalClassificationRule and IEntityApplicabilityPolicy.
*/


using CompoundHandbook.Domain;

namespace CompoundHandbook.Classification 
{
    /*
    The following class provides an implementation of the IChemicalEntityClassifier
    interface.

    The ':' between ChemicalEntityClassifier and IChemicalEntityClassifier indicates
    that ChemicalEntityClassifier implements that interface.

    Therefore, this class must provide an implementation of the Classify() method
    declared by IChemicalEntityClassifier.
    */
    public class ChemicalEntityClassifier : IChemicalEntityClassifier
    {
        /*
        Private read-only field that stores the collection of classification rules
        used by this classifier.

        IReadOnlyCollection<IChemicalClassificationRule> represents a collection whose
        elements can be accessed but cannot be added or removed through this interface.

        IChemicalClassificationRule is an interface itself, but is being used as the
        datatype of the objects contained inside this collection.

        Therefore, this collection can contain objects belonging to different classes,
        as long as those classes implement IChemicalClassificationRule.

        This allows ChemicalEntityClassifier to work with multiple different
        classification rules through the same common interface.

        The 'private' access modifier allows this field to be directly
        accessed from inside ChemicalEntityClassifier.

        The 'readonly' keyword means that the field can be assigned when it is declared
        or inside the constructor, but it cannot later be reassigned by the other
        methods of this class.
        */        
        private readonly IReadOnlyCollection<IChemicalClassificationRule> _ClassificationRules;

        /*
        Private read-only field that stores the applicability policy used to determine
        which ChemicalOperation values are appropriate for a ChemicalEntity.

        IEntityApplicabilityPolicy is an interface itself, but is being used as the
        datatype of this field.

        Therefore, ChemicalEntityClassifier does not need to know the particular class
        that contains the applicability logic.

        It only requires an object that implements IEntityApplicabilityPolicy and
        therefore provides the GetApplicableOperations() method.
        */
        private readonly IEntityApplicabilityPolicy _applicabilityPolicy;

        /*
        The following constructor will be called whenever a new
        ChemicalEntityClassifier object gets created.

        The constructor receives:
        (i)  A collection of IChemicalClassificationRule objects that will be used to evaluate the ChemicalEntity.
        (ii) An IEntityApplicabilityPolicy object that will be used to determine which ChemicalOperation values are applicable.

        These dependencies are supplied to ChemicalEntityClassifier instead of being
        created directly inside the class.

        The supplied arguments are then stored inside their corresponding private
        read-only fields so that they can later be used by the Classify() method.
        */
        public ChemicalEntityClassifier(IReadOnlyCollection<IChemicalClassificationRule> classificationRules, IEntityApplicabilityPolicy applicabilityPolicy)
        {
            // Stores the supplied collection of classification rules.
            _classificationRules = classificationRules;

            // Stores the supplied entity-applicability policy.
            _applicabilityPolicy = applicabilityPolicy;
        }

        /*
        The following Classify() method performs the overall classification process
        for the supplied ChemicalEntity.

        This method provides the implementation of the Classify() method required by
        the IChemicalEntityClassifier interface.

        ChemicalEntity entity:
        Represents the chemical entity that needs to be classified.

        ChemicalClassificationResult:
        Represents the completed result that will be returned after the classification
        process has finished.
        */
        public ChemicalClassificationResult Classify(ChemicalEntity entity)
        {
            /*
            First, the DetermineEntityType() method is called to determine the general
            ChemicalEntityType of the supplied ChemicalEntity.

            The returned ChemicalEntityType is stored inside the local variable
            entityType.
            */            
            ChemicalEntityType entityType = DetermineEntityType(entity);

            /*
            Creates an empty HashSet that will store the ChemicalCategory values
            identified by the different classification rules.

            HashSet<T> is a .NET generic collection that stores unique values.

            This is useful here because multiple classification rules could potentially
            contribute the same ChemicalCategory.

            For example, if two different classification rules both contribute the
            Organic category, the final Categories collection should still contain
            Organic only once.

            Therefore, HashSet<ChemicalCategory> allows the classifier to combine
            category contributions while automatically preventing duplicate
            ChemicalCategory values.
            */
            HashSet<ChemicalCategory> categories = new();

            /*
            The following foreach loop goes through every IChemicalClassificationRule
            contained inside _classificationRules.

            During each iteration, the variable 'rule' references one classification
            rule from the collection.
            */
            foreach (IChemicalClassificationRule rule in _classificationRules)
            {
                /*
                Calls the Evaluate() method of the current classification rule and
                supplies the ChemicalEntity being classified.

                Each rule performs its own classification logic and returns a
                ChemicalClassificationContribution.

                The returned contribution is stored inside the local variable
                contribution.
                */                
                ChemicalClassificationContribution contribution = rule.Evaluate(entity);

                /*
                A ChemicalClassificationContribution can contain multiple
                ChemicalCategory values.

                The following foreach loop goes through every category contributed
                by the current classification rule.
                */
                foreach (ChemicalCategory category in contribution.Categories)
                {
                    /*
                    Adds the contributed ChemicalCategory to the HashSet.

                    Because categories is a HashSet<ChemicalCategory>, the category
                    will only be stored if that value is not already present.

                    Therefore, duplicate category contributions from different
                    classification rules do not produce duplicate values in the
                    final category collection.
                    */                    
                    categories.Add(category);
                }
            }

            /*
            After the ChemicalCategory values have been collected, the classifier asks
            the IEntityApplicabilityPolicy to determine which ChemicalOperation values
            are applicable.

            GetApplicableOperations() receives:

            (i)  The ChemicalEntity being classified.
            (ii) The collection of ChemicalCategory values that were determined for it.

            categories is currently a HashSet<ChemicalCategory>.

            ToArray() creates an array containing the values stored inside that HashSet.

            An array can be supplied where IReadOnlyCollection<ChemicalCategory> is
            expected because arrays implement the required collection interfaces.

            The ChemicalOperation values returned by the applicability policy are stored
            inside applicableOperations.
            */
            IReadOnlyCollection<ChemicalOperation> applicableOperations = _applicabilityPolicy.GetApplicableOperations(entity, categories.ToArray());

            /*
            Creates and returns the completed ChemicalClassificationResult.

            The constructor receives:
            (i)   entityType: The general ChemicalEntityType determined earlier.
            (ii)  categories.ToArray(): The unique ChemicalCategory values collected from the classification rules.
            (iii) applicableOperations: The ChemicalOperation values determined by the IEntityApplicabilityPolicy.
            (iv)  Array.Empty<string>(): An empty collection of messages.

            Array.Empty<string>() returns an empty string array instead of requiring
            a new empty array to be manually created.

            At the current stage, this classifier does not produce any classification
            messages, so an empty collection is supplied to the Messages property of
            ChemicalClassificationResult.
            */
            return new ChemicalClassificationResult(entityType, categories.ToArray(), applicableOperations, Array.Empty<string>());
        }

        /*
        The following private helper method determines the general ChemicalEntityType
        represented by a ChemicalEntity object.

        This method is intended to be used only from inside ChemicalEntityClassifier.

        'static' means that the method belongs to the class itself and does not require
        access to the fields of a particular ChemicalEntityClassifier object.

        The method receives a ChemicalEntity and returns the corresponding
        ChemicalEntityType enum value.
        */
        private static ChemicalEntityType DetermineEntityType(ChemicalEntity entity)
        {
            /*
            The following code uses a C# switch expression together with type patterns.

            Instead of comparing the value of entity against ordinary constant values,
            each pattern checks the runtime type of the object referenced by entity.

            The expression therefore maps each specific ChemicalEntity-derived class
            to its corresponding ChemicalEntityType value.
            
            If the supplied ChemicalEntity does not belong to any of the
            currently recognized entity classes, ChemicalEntityType.Unknown is returned.
            */
            return entity switch
            {
                Molecule => ChemicalEntityType.Molecule,

                IonicSolid => ChemicalEntityType.IonicSolid,

                NetworkCovalentSolid => ChemicalEntityType.NetworkCovalentSolid,

                Metal => ChemicalEntityType.Metal,

                Polymer => ChemicalEntityType.Polymer,

                _ => ChemicalEntityType.Unknown
            };
        }
    }
}
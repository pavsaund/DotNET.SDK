/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readModels';

export class {{ReadModelName}} extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '{{ReadModelArtifactId}}',
           generation: '{{ReadModelGeneration}}'
        };
        {{#each Properties}}
        this.{{PropertyName}} = {{PropertyDefaultValue}};
        {{/each}}
    }
}
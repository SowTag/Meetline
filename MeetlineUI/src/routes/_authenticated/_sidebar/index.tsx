import { createFileRoute } from '@tanstack/react-router'

export const Route = createFileRoute('/_authenticated/_sidebar/')({
  component: RouteComponent,
})

function RouteComponent() {
  return <span>This should have a sidebar.</span>
}
